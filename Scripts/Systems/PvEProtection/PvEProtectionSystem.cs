namespace AtomicTorch.CBND.CoreMod.Systems.PvEProtection
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AtomicTorch.CBND.CoreMod.Characters.Player;
    using AtomicTorch.CBND.CoreMod.Helpers.Client;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Loot;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures;
    using AtomicTorch.CBND.CoreMod.Systems.Creative;
    using AtomicTorch.CBND.CoreMod.Systems.LandClaim;
    using AtomicTorch.CBND.CoreMod.Systems.Notifications;
    using AtomicTorch.CBND.CoreMod.Systems.PvE;
    using AtomicTorch.CBND.CoreMod.Triggers;
    using AtomicTorch.CBND.CoreMod.UI.Controls.Core.Menu;
    using AtomicTorch.CBND.CoreMod.UI.Controls.Game.Social;
    using AtomicTorch.CBND.GameApi;
    using AtomicTorch.CBND.GameApi.Data;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Items;
    using AtomicTorch.CBND.GameApi.Data.State;
    using AtomicTorch.CBND.GameApi.Data.World;
    using AtomicTorch.CBND.GameApi.Scripting;
    using AtomicTorch.CBND.GameApi.Scripting.Network;

    public class PvEProtectionSystem : ProtoSystem<PvEProtectionSystem>
    {
        public const string Button_CancelNewbieProtection =
            "Cancel newbie protection";

        public const string Dialog_CancelNewbieProtection =
            "Are you sure you want to cancel the newbie protection? You cannot enable it again.";

        public const string NewbieProtectionDescription =
            "You're under newbie protection. It protects you against losing your items if your character is killed by another player. Also, the items you drop in other cases of death cannot be looted by other players. Please follow the quests to craft the necessary tools and weapons, and build a small base as soon as possible!";

        public const string NewbieProtectionExpireInFormat =
            "The newbie protection will expire in:";

        public const string Notification_CanCancelProtection =
            "You can cancel this protection at any time in the social menu.";

        public const string Notification_CannotDamageOtherPlayersOrLootBags =
            "While under newbie protection you cannot attack other players or loot their bags or items.";

        public const string Notification_CannotPerformActionWhileUnderProtection =
            "You cannot perform this action while under newbie protection.";

        public const string Notification_LootBagUnderProtection =
            "This bag is under newbie protection, so only the owner can pick it up.";

        public const string Notification_ProtectionExpired =
            "The newbie protection has expired. You're now free to engage in PvP fights, but beware—your character will drop all items upon death.";

        public const string Title_NewbieProtection =
            "Newbie protection";

        private const int ServerUpdateInterval = 10;

        static PvEProtectionSystem()
        {
           
        }

        public static event Action<double> ClientPveProtectionTimeRemainingReceived;

        [NotLocalizable]
        public override string Name => "PvE protection system";

        
        public static void ClientNotifyNewbieCannotPerformAction(IProtoGameObject iconSource)
        {
            var icon = iconSource switch
            {
                IProtoStaticWorldObject protoStaticWorld => protoStaticWorld.Icon,
                IProtoItem protoItem                     => protoItem.Icon,
                _                                        => null
            };

            NotificationSystem.ClientShowNotification(
                title: Notification_CannotPerformActionWhileUnderProtection
                       + "[br]"
                       + Notification_CanCancelProtection,
                icon: icon,
                onClick: Menu.Open<WindowSocial>,
                color: NotificationColor.Bad);
        }

        protected override void PrepareSystem()
        {
            if (IsClient)
            {
                return;
            }

            TriggerTimeInterval.ServerConfigureAndRegister(
                callback: this.ServerUpdate,
                name: "System." + this.ShortId,
                interval: TimeSpan.FromSeconds(ServerUpdateInterval));
        }

        private void ServerUpdate()
        {
            
            //Instance.CallClient(ClientCurrentCharacterHelper.Character, _ => _.ClientRemote_SetPveProtection());
        }

        private void ClientRemote_SetPveProtection()
        {
            Logger.Info("Received PvE Protection");

            Api.SafeInvoke(
                () => ClientPveProtectionTimeRemainingReceived?.Invoke(0));
        }

        private class Bootstrapper : BaseBootstrapper
        {
            public override void ClientInitialize()
            {
                Client.Characters.CurrentPlayerCharacterChanged += Refresh;

                Refresh();

                void Refresh()
                {
                    if (Api.Client.Characters.CurrentPlayerCharacter is null)
                    {
                        return;
                    }

                    Logger.Warning("[PVE] System refresh");
                    //Instance.CallServer(_ => _.ServerRemote_GetNewbieProtectionTimeRemaining());
                }
            }
        }
    }
}