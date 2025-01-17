﻿namespace AtomicTorch.CBND.CoreMod.Systems.PvE
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;
    using AtomicTorch.CBND.CoreMod.Characters;
    using AtomicTorch.CBND.CoreMod.Characters.Player;
    using AtomicTorch.CBND.CoreMod.Helpers.Client;
    using AtomicTorch.CBND.CoreMod.Rates;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Trees;
    using AtomicTorch.CBND.CoreMod.Systems.Creative;
    using AtomicTorch.CBND.CoreMod.Systems.LandClaim;
    using AtomicTorch.CBND.CoreMod.Systems.Notifications;
    using AtomicTorch.CBND.CoreMod.Systems.Weapons;
    using AtomicTorch.CBND.CoreMod.Systems.WorldObjectClaim;
    using AtomicTorch.CBND.CoreMod.Systems.WorldObjectOwners;
    using AtomicTorch.CBND.CoreMod.UI;
    using AtomicTorch.CBND.CoreMod.Vehicles;
    using AtomicTorch.CBND.CoreMod.Systems.PvEZone;
    using AtomicTorch.CBND.GameApi;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.State;
    using AtomicTorch.CBND.GameApi.Data.World;
    using AtomicTorch.CBND.GameApi.Scripting;
    using AtomicTorch.CBND.GameApi.Scripting.Network;

    public class PveSystem : ProtoSystem<PveSystem>
    {
        public const string DuelMode_Button_Disable = "Disable duel mode";

        public const string DuelMode_Button_Enable = "Enable duel mode";

        public const string DuelMode_Description =
            @"You can enable duel mode in order to challenge other players to a fight.
              [br]You do not lose items upon death.
              [br]Both players must have duel mode enabled.";

        public const string DuelMode_Title = "Duel Mode";

        public const string Notification_CannotDamagePlayers_Message =
            "You cannot damage other players or structures belonging to a player on a PvE server.";

        public const string Notification_OtherPlayerDontHaveDuelMode_Message =
            "Both players must enable Duel Mode in order to fight.";

        // Displayed when player attempting to take the dropped loot of another player on a PvE server.
        public const string Notification_StuffBelongsToAnotherPlayer_Message =
            "This belongs to another player.";

        [NotLocalizable]
        private const string ServerTagPvE = "PvE";

        [NotLocalizable]
        private const string ServerTagPvP = "PvP";

        private static bool? clientIsPvE;

        private static TaskCompletionSource<bool> clientPvErequestTask
            = new();

        public static event Action ClientIsPvEChanged;

        public static bool ClientIsDuelModeEnabled
        {
            get => SharedIsDuelModeEnabled(ClientCurrentCharacterHelper.Character);
            set
            {
                if (ClientIsDuelModeEnabled == value)
                {
                    return;
                }

                Instance.CallServer(_ => _.ServerRemote_SetDuelMode(value));
            }
        }

        public static bool ClientIsPveFlagReceived => clientIsPvE.HasValue;

        public static bool ServerIsPvE => !RatePvPIsEnabled.SharedValue;

        [NotLocalizable]
        public override string Name => "PvE system";

        public static Task ClientAwaitPvEModeFromServer()
        {
            return clientPvErequestTask.Task;
        }

        public static bool ClientIsPve(bool logErrorIfDataIsNotYetAvailable)
        {
            if (clientIsPvE.HasValue)
            {
                return clientIsPvE.Value;
            }

            Api.ValidateIsClient();
            if (logErrorIfDataIsNotYetAvailable)
            {
                Logger.Error("Client has not yet received PvP/PvE server mode");
            }

            return false;
        }

        public static void ClientShowDuelModeRequiredNotificationIfNecessary(
            ICharacter characterA,
            ICharacter characterB)
        {
            if (!ClientIsPve(logErrorIfDataIsNotYetAvailable: false)
                || characterA.IsNpc
                || characterB.IsNpc)
            {
                return;
            }

            var isDuelModeA = SharedIsDuelModeEnabled(characterA);
            var isDuelModeB = SharedIsDuelModeEnabled(characterB);
            if (isDuelModeA && isDuelModeB)
            {
                // duel mode is allowed
                return;
            }

            if (!isDuelModeA
                && !isDuelModeB)
            {
                ClientShowNotificationCannotDamagePlayersAndStructures();
                return;
            }

            NotificationSystem.ClientShowNotification(
                DuelMode_Title,
                Notification_OtherPlayerDontHaveDuelMode_Message,
                NotificationColor.Bad);
        }

        public static void ClientShowNotificationActionForbidden()
        {
            NotificationSystem.ClientShowNotification(
                CoreStrings.Notification_ActionForbidden,
                Notification_StuffBelongsToAnotherPlayer_Message,
                color: NotificationColor.Bad);
        }

        public static bool SharedAllowPvPDamage(ICharacter characterA, ICharacter characterB)
        {
            if (!SharedIsPve(clientLogErrorIfDataIsNotYetAvailable: false)
                || characterA.IsNpc
                || characterB.IsNpc
                || ReferenceEquals(characterA, characterB))
            {
                return true;
            }

            return SharedIsDuelModeEnabled(characterA)
                   && SharedIsDuelModeEnabled(characterB);
        }

        public static bool SharedIsAllowStaticObjectDamage(
            ICharacter character,
            IStaticWorldObject targetObject,
            bool showClientNotification)
        {
            if (!WorldObjectClaimSystem.SharedIsAllowInteraction(character,
                                                                 targetObject,
                                                                 showClientNotification))
            {
                return false;
            }

            var protoWorldObject = targetObject.ProtoWorldObject;
            var isStructure = protoWorldObject is IProtoObjectStructure;
            var isProtectedVegetation = protoWorldObject is IProtoObjectPlant
                                        || protoWorldObject is IProtoObjectTree;
            if (!isStructure
                && !isProtectedVegetation)
            {
                // can damage such objects everywhere
                return true;
            }

            if (!LandClaimSystem.SharedIsObjectInsideAnyArea(targetObject))
            {
                // always allow damage outside of land claim areas
                return true;
            }

            if (character is null)
            {
                // non-player damage is always forbidden on the owned objects
                return false;
            }

            if (!SharedIsPve(clientLogErrorIfDataIsNotYetAvailable: false) && !PvEZone.IsNoDamageOriginInPvP(character, targetObject))
            {
                return true;
            }

            if (LandClaimSystem.SharedIsObjectInsideOwnedOrFreeArea(targetObject,
                                                                    character,
                                                                    requireFactionPermission: false))
            {
                if (isProtectedVegetation)
                {
                    // allow damaging vegetation in the owned land claim area
                    return true;
                }

                // don't allow damaging the structures in the owned land claim area
                return false;
            }

            // don't allow damage as the object is inside the not-owned land claim area
            if (IsClient && showClientNotification)
            {
                ClientShowNotificationCannotDamagePlayersAndStructures();
            }

            return false;
        }

        public static bool SharedIsAllowVehicleDamage(
            WeaponFinalCache weaponCache,
            IDynamicWorldObject targetObject,
            bool showClientNotification)
        {
            if (!SharedIsPve(clientLogErrorIfDataIsNotYetAvailable: false) && !PvEZone.IsPvEZone(weaponCache.Character))
            {
                return true;
            }

            if (IsClient)
            {
                // unfortunately we cannot perform owner check on the client
                return true;
            }

            var pilot = targetObject.GetPublicState<VehiclePublicState>()
                                    .PilotCharacter;

            if (weaponCache.Character is null)
            {
                // vehicle cannot be damaged by explosions and other non-player stuff
                return false;
            }

            if (WorldObjectOwnersSystem.SharedIsOwner(weaponCache.Character, targetObject))
            {
                // vehicle damage by vehicle owner is disabled in PvE
                return false;
            }

            if (weaponCache.Character?.ProtoGameObject is IProtoCharacterMob protoCharacterMob)
            {
                if (protoCharacterMob.IsBoss)
                {
                    // boss can damage any vehicle
                    return true;
                }

                if (pilot is null
                    && ((IProtoVehicle)targetObject.ProtoGameObject).IsAllowCreatureDamageWhenNoPilot)
                {
                    return true;
                }
            }

            if (pilot is not null
                && WeaponDamageSystem.SharedCanHitCharacter(weaponCache,
                                                            targetCharacter: pilot))
            {
                // probably the pilot character is in the Duel mode
                return true;
            }

            // commented out as it's definitely server side code
            //if (IsClient && showClientNotification)
            //{
            //    ClientShowNotificationCannotDamagePlayersAndStructures();
            //}

            return false;
        }

        public static bool SharedIsDuelModeEnabled(ICharacter character)
        {
            if (character.IsNpc)
            {
                return true;
            }

            return false;
        }

        public static bool SharedIsPve(bool clientLogErrorIfDataIsNotYetAvailable)
        {
            if (IsServer)
            {
                return ServerIsPvE;
            }

            return ClientIsPve(clientLogErrorIfDataIsNotYetAvailable);
        }

        public static bool SharedValidateInteractionIsNotForbidden(
            ICharacter character,
            IStaticWorldObject worldObject,
            bool writeToLog)
        {
            if (!SharedIsPve(clientLogErrorIfDataIsNotYetAvailable: true) && !PvEZone.IsPvEZone(character))
            {
                return true;
            }

            if (!WorldObjectClaimSystem.SharedIsAllowInteraction(character,
                                                                 worldObject,
                                                                 showClientNotification: writeToLog))
            {
                return false;
            }

            if (LandClaimSystem.SharedIsObjectInsideOwnedOrFreeArea(worldObject,
                                                                    character,
                                                                    requireFactionPermission: false)
                || CreativeModeSystem.SharedIsInCreativeMode(character))
            {
                return true;
            }

            // if we're here, this is PvE and the object is inside another players' land claim area
            // allow interacting with anything except player-built structures and plants
            switch (worldObject.ProtoStaticWorldObject)
            {
                case IProtoObjectStructure:
                case IProtoObjectPlant:
                    if (IsClient && writeToLog)
                    {
                        ClientShowNotificationActionForbidden();
                    }

                    return false;

                default:
                    return true;
            }
        }

        [SuppressMessage("ReSharper", "CanExtractXamlLocalizableStringCSharp")]
        protected override void PrepareSystem()
        {
            base.PrepareSystem();

            if (IsClient)
            {
                return;
            }

            var isPvE = ServerIsPvE;
            Server.Core.AddServerInfoTag(isPvE
                                             ? ServerTagPvE
                                             : ServerTagPvP);

            if (isPvE)
            {
                Server.Characters.PlayerOnlineStateChanged += ServerPlayerOnlineStateChangedHandler;
            }
        }

        private static void ClientShowNotificationCannotDamagePlayersAndStructures()
        {
            NotificationSystem.ClientShowNotification(
                CoreStrings.Notification_ActionForbidden,
                Notification_CannotDamagePlayers_Message,
                color: NotificationColor.Bad);
        }

        private static void ServerPlayerOnlineStateChangedHandler(ICharacter character, bool isOnline)
        {
            if (!isOnline)
            {
                ServerSetDuelMode(character, isEnabled: false);
            }
        }

        private static void ServerSetDuelMode(ICharacter character, bool isEnabled)
        {
            if (!ServerIsPvE && isEnabled)
            {
                isEnabled = false;
                Logger.Info("Cannot switch PvE duel mode to enabled on PvP servers",
                            character);
            }

            var publicState = PlayerCharacter.GetPublicState(character);
            if (publicState.IsPveDuelModeEnabled == isEnabled)
            {
                return;
            }

            publicState.IsPveDuelModeEnabled = isEnabled;
            Logger.Important("Switched PvE duel mode to " + (isEnabled ? "enabled" : "disabled"), character);
        }

        [RemoteCallSettings(DeliveryMode.ReliableSequenced, timeInterval: 1)]
        private void ServerRemote_SetDuelMode(bool isEnabled)
        {
            ServerSetDuelMode(ServerRemoteContext.Character, isEnabled);
        }

        private class Bootstrapper : BaseBootstrapper
        {
            public override void ClientInitialize()
            {
                Client.CurrentGame.ServerInfoChanged += Refresh;
                Refresh();

                static void Refresh()
                {
                    var serverInfo = Client.CurrentGame.ServerInfo;
                    if (serverInfo is null)
                    {
                        return;
                    }

                    clientPvErequestTask?.TrySetCanceled();
                    clientPvErequestTask = new TaskCompletionSource<bool>();
                    var isPvE = serverInfo.ScriptingTags.Contains(ServerTagPvE);
                    try
                    {
                        if (clientIsPvE == isPvE)
                        {
                            return;
                        }

                        clientIsPvE = isPvE;
                        if (ClientIsPvEChanged is not null)
                        {
                            Api.SafeInvoke(ClientIsPvEChanged);
                        }
                    }
                    finally
                    {
                        clientPvErequestTask.SetResult(isPvE);
                    }
                }
            }
        }
    }
}