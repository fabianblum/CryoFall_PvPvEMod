﻿namespace AtomicTorch.CBND.CoreMod.Systems.TradingStations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AtomicTorch.CBND.CoreMod.ItemContainers;
    using AtomicTorch.CBND.CoreMod.Items;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Fridges;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.TradingStations;
    using AtomicTorch.CBND.CoreMod.Systems.Creative;
    using AtomicTorch.CBND.CoreMod.Systems.Droplists;
    using AtomicTorch.CBND.CoreMod.Systems.ItemDurability;
    using AtomicTorch.CBND.CoreMod.Systems.ItemFreshnessSystem;
    using AtomicTorch.CBND.CoreMod.Systems.Notifications;
    using AtomicTorch.CBND.CoreMod.Systems.PvE;
    using AtomicTorch.CBND.CoreMod.Systems.WorldObjectOwners;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Items;
    using AtomicTorch.CBND.GameApi.Data.State;
    using AtomicTorch.CBND.GameApi.Data.State.NetSync;
    using AtomicTorch.CBND.GameApi.Data.World;
    using AtomicTorch.CBND.GameApi.Resources;
    using AtomicTorch.CBND.GameApi.Scripting;
    using AtomicTorch.CBND.GameApi.Scripting.Network;
    using AtomicTorch.CBND.GameApi.ServicesServer;
    using AtomicTorch.GameEngine.Common.Extensions;

    public class TradingStationsSystem : ProtoSystem<TradingStationsSystem>
    {
        public const string NotificationBoughtTitle = "Bought";

        public const string NotificationNeedMorePennyCoins = "Need {0} more penny coins.";

        public const string NotificationNeedMoreShinyCoins = "Need {0} more shiny coins.";

        public const string NotificationSoldTitle = "Sold";

        public const string NotiticationCannotBuy_Title = "Cannot buy";

        public const string NotiticationCannotSell_Title = "Cannot sell";

        private const double MinQualityFractionWhenStationBuying = 0.95;

        // how long the items dropped on the ground from the destroyed trading station should remain there
        private static readonly TimeSpan DestroyedTradingStationDroppedItemsDestructionTimeout
            = TimeSpan.FromMinutes(15);

        private static readonly Lazy<IProtoItem> ProtoItemCoinPenny
            = new(GetProtoEntity<ItemCoinPenny>);

        private static readonly Lazy<IProtoItem> ProtoItemCoinShiny
            = new(GetProtoEntity<ItemCoinShiny>);

        private static readonly IItemsServerService ServerItems = IsServer ? Server.Items : null;

        public override string Name => "Trading stations system";

        public static async void ClientRequestExecuteTrade(
            IStaticWorldObject tradingStation,
            TradingStationLot lot,
            bool isPlayerBuying)
        {
            var mode = isPlayerBuying
                           ? TradingStationMode.StationSelling
                           : TradingStationMode.StationBuying;

            if (!Instance.SharedValidateCanTrade(tradingStation,
                                                 lot,
                                                 mode,
                                                 Client.Characters.CurrentPlayerCharacter,
                                                 out var checkResult))
            {
                ClientShowErrorNotification(lot, checkResult, isPlayerBuying);
                return;
            }

            var publicState = GetPublicState(tradingStation);
            var lotIndex = publicState.Lots.IndexOf(lot);
            checkResult = await Instance.CallServer(
                              _ => _.ServerRemote_ExecuteTrade(tradingStation,
                                                               (byte)lotIndex,
                                                               mode));
            if (checkResult != TradingResult.Success)
            {
                ClientShowErrorNotification(lot, checkResult, isPlayerBuying);
            }
            else
            {
                ClientShowSuccessNotification(lot, isPlayerBuying);
            }
        }

        public static void ClientSendStationSetMode(
            IStaticWorldObject tradingStation,
            TradingStationMode mode)
        {
            Instance.CallServer(_ => _.ServerRemote_StationSetMode(tradingStation, mode));
        }

        public static void ClientSendTradingLotModification(
            TradingStationLot lot,
            IProtoItem protoItem,
            ushort lotQuantity,
            ushort priceCoinPenny,
            ushort priceCoinShiny)
        {
            var tradingStation = lot.GameObject as IStaticWorldObject;
            var publicState = GetPublicState(tradingStation);
            var lotIndex = publicState.Lots.IndexOf(lot);

            Instance.CallServer(
                _ => _.ServerRemote_SetTradingLot(tradingStation,
                                                  (byte)lotIndex,
                                                  protoItem,
                                                  lotQuantity,
                                                  priceCoinPenny,
                                                  priceCoinShiny));
        }

        public static void ServerInitialize(IStaticWorldObject tradingStation)
        {
            if (tradingStation.ProtoStaticWorldObject
                    is not IProtoObjectTradingStation protoTradingStation)
            {
                throw new Exception($"Not an {typeof(IProtoObjectTradingStation).FullName}: {tradingStation}");
            }

            TradingStationsMapMarksSystem.ServerTryAddMark(tradingStation);

            var privateState = GetPrivateState(tradingStation);
            var publicState = GetPublicState(tradingStation);

            if (privateState.StockItemsContainer is null)
            {
                //MOD
                if (tradingStation.ProtoStaticWorldObject is IProtoObjectFridge)
                {
                    privateState.StockItemsContainer = ServerItems.CreateContainer(
                            tradingStation,
                            Api.GetProtoEntity<ItemsContainerFridge>(),
                            protoTradingStation.StockItemsContainerSlotsCount);
                }
                else
                {
                    privateState.StockItemsContainer = ServerItems.CreateContainer(
                            tradingStation,
                            protoTradingStation.StockItemsContainerSlotsCount);
                }
            }
            else
            {
                ServerItems.SetSlotsCount(privateState.StockItemsContainer,
                                          protoTradingStation.StockItemsContainerSlotsCount);
            }

            var lots = publicState.Lots
                           ??= new NetworkSyncList<TradingStationLot>(capacity: protoTradingStation.LotsCount);

            // ensure that the lots count is not exceeded
            while (lots.Count > protoTradingStation.LotsCount)
            {
                lots.RemoveAt(protoTradingStation.LotsCount - 1);
            }

            for (var i = 0; i < protoTradingStation.LotsCount; i++)
            {
                if (lots.Count <= i)
                {
                    lots.Add(new TradingStationLot());
                }
                else if (lots[i] is null)
                {
                    lots[i] = new TradingStationLot();
                }
            }

            ServerRefreshTradingStationLots(tradingStation,
                                            privateState,
                                            publicState);
        }

        public static void ServerOnDestroy(IStaticWorldObject tradingStation)
        {
            TradingStationsMapMarksSystem.ServerTryRemoveMark(tradingStation);

            var itemsContainer = GetPrivateState(tradingStation).StockItemsContainer;
            ObjectGroundItemsContainer.ServerTryDropOnGroundContainerContent(
                tradingStation.OccupiedTile,
                itemsContainer,
                DestroyedTradingStationDroppedItemsDestructionTimeout.TotalSeconds);
        }

        public static void ServerUpdate(IStaticWorldObject tradingStation)
        {
            var privateState = GetPrivateState(tradingStation);
            if (privateState.LastStockItemsContainerHash == privateState.StockItemsContainer.StateHash)
            {
                return;
            }

            var publicState = GetPublicState(tradingStation);
            ServerRefreshTradingStationLots(tradingStation,
                                            privateState,
                                            publicState);
        }

        private static void ClientShowErrorNotification(
            TradingStationLot lot,
            TradingResult error,
            bool isPlayerBuying)
        {
            var message = error.GetDescription();

            if (error == TradingResult.ErrorNotEnoughMoneyOnPlayer)
            {
                // calculate how many coins are needed
                var character = Client.Characters.CurrentPlayerCharacter;
                long deficitShiny = 0,
                     deficitPenny = 0;

                if (lot.PriceCoinShiny > 0)
                {
                    deficitShiny = lot.PriceCoinShiny
                                   - character.CountItemsOfType(ProtoItemCoinShiny.Value);
                }

                if (lot.PriceCoinPenny > 0)
                {
                    deficitPenny = lot.PriceCoinPenny
                                   - character.CountItemsOfType(ProtoItemCoinPenny.Value);
                }

                if (deficitShiny > 0
                    || deficitPenny > 0)
                {
                    if (deficitShiny > 0)
                    {
                        // ReSharper disable once CanExtractXamlLocalizableStringCSharp
                        message += "[br]"
                                   + string.Format(NotificationNeedMoreShinyCoins, deficitShiny);
                    }

                    if (deficitPenny > 0)
                    {
                        // ReSharper disable once CanExtractXamlLocalizableStringCSharp
                        message += "[br]"
                                   + string.Format(NotificationNeedMorePennyCoins, deficitPenny);
                    }
                }
            }

            NotificationSystem.ClientShowNotification(
                isPlayerBuying
                    ? NotiticationCannotBuy_Title
                    : NotiticationCannotSell_Title,
                message,
                NotificationColor.Bad,
                icon: lot.ProtoItem.Icon);
        }


        private static void ClientShowSuccessNotification(
            TradingStationLot lot,
            bool isPlayerBuying)
        {
            Client.Audio.PlayOneShot(new SoundResource("UI/Notifications/ItemTradeSuccess"));
            NotificationSystem.ClientShowNotification(
                title: isPlayerBuying
                           ? NotificationBoughtTitle
                           : NotificationSoldTitle,
                // ReSharper disable once CanExtractXamlLocalizableStringCSharp
                message: $"{lot.ProtoItem.Name} ({lot.LotQuantity}).",
                color: NotificationColor.Good,
                icon: lot.ProtoItem.Icon,
                playSound: false);
        }

        private static ObjectTradingStationPrivateState GetPrivateState(IStaticWorldObject tradingStation)
        {
            return tradingStation.GetPrivateState<ObjectTradingStationPrivateState>();
        }

        private static StaticObjects.Structures.TradingStations.ObjectTradingStationPublicState GetPublicState(IStaticWorldObject tradingStation)
        {
            return tradingStation.GetPublicState<StaticObjects.Structures.TradingStations.ObjectTradingStationPublicState>();
        }

        private static TradingResult ServerExecuteTrade(
            TradingStationLot lot,
            IItemsContainerProvider sellerContainers,
            IItemsContainerProvider buyerContainers,
            bool isPlayerBuying)
        {
            // find items to buy by other party
            if (!SharedTryFindItemsOfType(sellerContainers,
                                          lot.ProtoItem,
                                          lot.LotQuantity,
                                          out var itemsToSell,
                                          minQualityFraction: isPlayerBuying
                                                                  ? 0
                                                                  : MinQualityFractionWhenStationBuying))
            {
                return isPlayerBuying
                           ? TradingResult.ErrorNotEnoughItemsOnStation
                           : TradingResult.ErrorNotEnoughItemsOnPlayer;
            }

            // try to find money to pay to other party
            var countCoinPenny = (uint)lot.PriceCoinPenny;
            var countCoinShiny = (uint)lot.PriceCoinShiny;
            if (!SharedTryFindItemsOfType(buyerContainers,
                                          ProtoItemCoinPenny.Value,
                                          countCoinPenny,
                                          out _,
                                          minQualityFraction: 0)
                || !SharedTryFindItemsOfType(buyerContainers,
                                             ProtoItemCoinShiny.Value,
                                             countCoinShiny,
                                             out _,
                                             minQualityFraction: 0))
            {
                return isPlayerBuying
                           ? TradingResult.ErrorNotEnoughMoneyOnStation
                           : TradingResult.ErrorNotEnoughMoneyOnPlayer;
            }

            // ensure there is enough space to store the sold items
            if (!ServerItems.CanCreateItem(buyerContainers, lot.ProtoItem, lot.LotQuantity))
            {
                return isPlayerBuying
                           ? TradingResult.ErrorNotEnoughSpaceOnPlayerForPurchasedItem
                           : TradingResult.ErrorNotEnoughSpaceOnStationForSoldItem;
            }

            // try create money in the source containers
            var sourceContainerResult = new CreateItemResult() { IsEverythingCreated = true };
            if (lot.PriceCoinPenny > 0)
            {
                sourceContainerResult.MergeWith(
                    ServerItems.CreateItem(ProtoItemCoinPenny.Value,
                                           sellerContainers,
                                           countCoinPenny));
            }

            if (lot.PriceCoinShiny > 0)
            {
                sourceContainerResult.MergeWith(
                    ServerItems.CreateItem(ProtoItemCoinShiny.Value,
                                           sellerContainers,
                                           countCoinShiny));
            }

            if (!sourceContainerResult.IsEverythingCreated)
            {
                sourceContainerResult.Rollback();
                // TODO: check this
                return isPlayerBuying
                           ? TradingResult.ErrorNotEnoughSpaceOnStationForSoldItem
                           : TradingResult.ErrorNotEnoughSpaceOnPlayerForPurchasedItem;
            }

            // try moving (bought) items
            var itemsCountToDestroyRemains = (int)lot.LotQuantity;
            foreach (var item in itemsToSell)
            {
                if (itemsCountToDestroyRemains <= 0)
                {
                    break;
                }

                ServerItems.MoveOrSwapItem(item,
                                           buyerContainers,
                                           out var movedCount,
                                           countToMove: (ushort)itemsCountToDestroyRemains);
                itemsCountToDestroyRemains -= movedCount;
            }

            if (itemsCountToDestroyRemains > 0)
            {
                // should be impossible
                Logger.Error(
                    "Cannot move all sold items! But we've verified that the sellerContainers have them all...");
            }

            if (countCoinPenny > 0)
            {
                ServerItems.DestroyItemsOfType(buyerContainers, ProtoItemCoinPenny.Value, countCoinPenny, out _);
            }

            if (countCoinShiny > 0)
            {
                ServerItems.DestroyItemsOfType(buyerContainers, ProtoItemCoinShiny.Value, countCoinShiny, out _);
            }

            Logger.Important($"Successfully completed trading transaction: {lot}");
            return TradingResult.Success;
        }

        private static void ServerRefreshTradingStationLots(
            IStaticWorldObject tradingStation,
            ObjectTradingStationPrivateState privateState,
            StaticObjects.Structures.TradingStations.ObjectTradingStationPublicState publicState)
        {
            var stockContainer = privateState.StockItemsContainer;
            privateState.LastStockItemsContainerHash = stockContainer.StateHash;

            int availableCoinPenny = stockContainer.CountItemsOfType(ProtoItemCoinPenny.Value),
                availableCoinShiny = stockContainer.CountItemsOfType(ProtoItemCoinShiny.Value);

            var isStationSelling = publicState.Mode == TradingStationMode.StationSelling;

            foreach (var lot in publicState.Lots)
            {
                if (lot.State == TradingStationLotState.Disabled)
                {
                    lot.CountAvailable = 0;
                    lot.ItemOnSale = null;
                    continue;
                }

                if (lot.ProtoItem is null
                    || !(lot.PriceCoinPenny > 0 || lot.PriceCoinShiny > 0)
                    || lot.LotQuantity < 1
                    || lot.LotQuantity > TradingStationLot.MaxLotQuantity)
                {
                    lot.CountAvailable = 0;
                    lot.ItemOnSale = null;
                    lot.State = TradingStationLotState.Disabled;
                    continue;
                }

                uint countAvailable;
                if (isStationSelling)
                {
                    // calculate how much items the station can sell
                    countAvailable = (uint)stockContainer.CountItemsOfType(lot.ProtoItem);
                    if (countAvailable > 0)
                    {
                        lot.ItemOnSale = stockContainer.Items.FirstOrDefault(i => i.ProtoItem == lot.ProtoItem);

                        // it can accomodate at least one item
                        // check that there is enough space to accomodate money
                        if (lot.PriceCoinPenny > 0
                            && !ServerItems.CanCreateItem(stockContainer,
                                                          ProtoItemCoinPenny.Value,
                                                          count: lot.PriceCoinPenny)
                            || lot.PriceCoinShiny > 0
                            && !ServerItems.CanCreateItem(stockContainer,
                                                          ProtoItemCoinShiny.Value,
                                                          count: lot.PriceCoinShiny))
                        {
                            lot.CountAvailable = 0;
                            lot.State = TradingStationLotState.NoSpace;
                            continue;
                        }
                    }
                    else
                    {
                        lot.ItemOnSale = null;
                    }
                }
                else // if station is buying
                {
                    lot.ItemOnSale = null;

                    // calculate how much station can buy considering the available amount of coins and the price of the lot
                    var canAffordWithPenny = lot.PriceCoinPenny > 0
                                                 ? availableCoinPenny / lot.PriceCoinPenny
                                                 : int.MaxValue;
                    var canAffordWithShiny = lot.PriceCoinShiny > 0
                                                 ? availableCoinShiny / lot.PriceCoinShiny
                                                 : int.MaxValue;

                    countAvailable = (uint)(Math.Min(canAffordWithPenny, canAffordWithShiny)
                                            * lot.LotQuantity);
                    if (countAvailable > 0)
                    {
                        // it can afford at least one item
                        // check that there is enough space to accomodate item
                        if (!ServerItems.CanCreateItem(stockContainer,
                                                       lot.ProtoItem,
                                                       count: lot.LotQuantity))
                        {
                            lot.CountAvailable = 0;
                            lot.State = TradingStationLotState.NoSpace;
                            continue;
                        }
                    }
                }

                if (PveSystem.ServerIsPvE)
                {
                    lot.CountAvailable = countAvailable;
                }
                else
                {
                    // It's important to not disclose this info on PvP servers.
                    lot.CountAvailable = countAvailable >= lot.LotQuantity
                                             ? 1u
                                             : 0u;
                }

                lot.State = countAvailable >= lot.LotQuantity
                                ? TradingStationLotState.Available
                                : isStationSelling
                                    ? TradingStationLotState.OutOfStock
                                    : TradingStationLotState.NoMoney;
            }

            TradingStationsMapMarksSystem.ServerRefreshMark(tradingStation);
        }

        private static bool SharedTryFindItemsOfType(
            IItemsContainerProvider containers,
            IProtoItem requiredProtoItem,
            uint count,
            out List<IItem> result,
            double minQualityFraction)
        {
            var countToFindRemains = (int)count;

            result = new List<IItem>();
            foreach (var container in containers.Containers)
            {
                foreach (var item in container.Items)
                {
                    if (item.ProtoItem != requiredProtoItem)
                    {
                        continue;
                    }

                    if (requiredProtoItem is IProtoItemWithDurability
                        && ItemDurabilitySystem.SharedGetDurabilityFraction(item) < minQualityFraction)
                    {
                        // not enough durability
                        continue;
                    }

                    if (requiredProtoItem is IProtoItemWithFreshness
                        && ItemFreshnessSystem.SharedGetFreshnessFraction(item) < minQualityFraction)
                    {
                        // not enough durability
                        continue;
                    }

                    result.Add(item);
                    countToFindRemains -= item.Count;
                    if (countToFindRemains <= 0)
                    {
                        break;
                    }
                }

                if (countToFindRemains <= 0)
                {
                    break;
                }
            }

            return countToFindRemains <= 0;
        }

        private static void ValidateCanAdminAndInteract(ICharacter character, IStaticWorldObject tradingStation)
        {
            /*if (!tradingStation.ProtoStaticWorldObject
                               .SharedCanInteract(character, tradingStation, writeToLog: true))
            {
                throw new Exception($"{character} cannot interact with {tradingStation}");
            }

            if (!WorldObjectOwnersSystem.SharedIsOwner(character, tradingStation)
                && !CreativeModeSystem.SharedIsInCreativeMode(character))
            {
                throw new Exception($"{character} is not owner of {tradingStation}");
            }*/
        }

        private TradingResult ServerRemote_ExecuteTrade(
            IStaticWorldObject tradingStation,
            byte lotIndex,
            TradingStationMode mode)
        {
            var character = ServerRemoteContext.Character;
            var lot = GetPublicState(tradingStation).Lots[lotIndex];
            if (!this.SharedValidateCanTrade(tradingStation, lot, mode, character, out var error))
            {
                return error;
            }

            Logger.Important($"Processing trading transaction: {lot}, mode={mode}", character);

            var tradingStationPrivateState = GetPrivateState(tradingStation);
            var tradingStationItemsContainer = tradingStationPrivateState.StockItemsContainer;

            if (mode == TradingStationMode.StationSelling)
            {
                return ServerExecuteTrade(
                    lot,
                    sellerContainers: new AggregatedItemsContainers(tradingStationItemsContainer),
                    buyerContainers: new CharacterContainersProvider(character, includeEquipmentContainer: false),
                    isPlayerBuying: true);
            }

            // station buying
            return ServerExecuteTrade(
                lot,
                sellerContainers: new CharacterContainersProvider(character, includeEquipmentContainer: false),
                buyerContainers: new AggregatedItemsContainers(tradingStationItemsContainer),
                isPlayerBuying: false);
        }

        public static void CallServerRemote_SetTradingLot(
            IStaticWorldObject tradingStation,
            byte lotIndex,
            IProtoItem protoItem,
            ushort lotQuantity,
            ushort priceCoinPenny,
            ushort priceCoinShiny)
        {
            Instance.ServerRemote_SetTradingLot(tradingStation, lotIndex, protoItem, lotQuantity, priceCoinPenny, priceCoinShiny);
        }

        private void ServerRemote_SetTradingLot(
            IStaticWorldObject tradingStation,
            byte lotIndex,
            IProtoItem protoItem,
            ushort lotQuantity,
            ushort priceCoinPenny,
            ushort priceCoinShiny)
        {
            var character = ServerRemoteContext.Character;
            if (null != character)
            {
                ValidateCanAdminAndInteract(character, tradingStation);
            }

            var publicState = GetPublicState(tradingStation);
            var lot = publicState.Lots[lotIndex];

            lot.ProtoItem = protoItem;
            lot.SetLotQuantity(lotQuantity);
            lot.SetPrices(priceCoinPenny, priceCoinShiny);
            // the state will be set automatically during the refresh
            lot.State = TradingStationLotState.Available;

            Logger.Important($"Successfully modified trading lot #{lotIndex} on {tradingStation}", character);
            ServerRefreshTradingStationLots(tradingStation,
                                            GetPrivateState(tradingStation),
                                            publicState);
        }

        [RemoteCallSettings(DeliveryMode.ReliableSequenced, timeInterval: 1, keyArgIndex: 0)]
        private void ServerRemote_StationSetMode(IStaticWorldObject tradingStation, TradingStationMode mode)
        {
            ValidateCanAdminAndInteract(ServerRemoteContext.Character, tradingStation);

            var publicState = GetPublicState(tradingStation);
            publicState.Mode = mode;

            foreach (var lot in publicState.Lots)
            {
                lot.State = TradingStationLotState.Disabled;
            }

            Logger.Important($"{tradingStation} mode switched to {mode}");
            ServerRefreshTradingStationLots(tradingStation,
                                            GetPrivateState(tradingStation),
                                            publicState);
        }

        private bool SharedValidateCanTrade(
            IStaticWorldObject tradingStation,
            TradingStationLot lot,
            TradingStationMode mode,
            ICharacter character,
            out TradingResult error)
        {
            var protoTradingStation = tradingStation.ProtoStaticWorldObject;

            var publicState = GetPublicState(tradingStation);
            if (publicState.Mode != mode)
            {
                throw new Exception("Trading station has different trading mode");
            }

            if (!protoTradingStation
                    .SharedCanInteract(character, tradingStation, writeToLog: false))
            {
                error = TradingResult.ErrorCannotInteract;
                return false;
            }

            var lots = publicState.Lots;

            var isLotFound = false;
            foreach (var otherLot in lots)
            {
                if (otherLot == lot)
                {
                    // found lot
                    isLotFound = true;
                    break;
                }
            }

            if (!isLotFound)
            {
                error = TradingResult.ErrorLotNotFound;
                return false;
            }

            if (lot.State == TradingStationLotState.Disabled)
            {
                error = TradingResult.ErrorLotNotActive;
                return false;
            }

            if (mode == TradingStationMode.StationBuying)
            {
                // ensure that the character has required item count to sell
                if (lot.LotQuantity > character.CountItemsOfType(lot.ProtoItem))
                {
                    error = TradingResult.ErrorNotEnoughItemsOnPlayer;
                    return false;
                }

                if (IsServer)
                {
                    // ensure station has enough money to pay for these items
                    var tradingStationItemsContainer = GetPrivateState(tradingStation).StockItemsContainer;
                    if (!tradingStationItemsContainer.ContainsItemsOfType(
                            ProtoItemCoinPenny.Value,
                            requiredCount: lot.PriceCoinPenny)
                        || !tradingStationItemsContainer.ContainsItemsOfType(
                            ProtoItemCoinShiny.Value,
                            requiredCount: lot.PriceCoinShiny))
                    {
                        error = TradingResult.ErrorNotEnoughMoneyOnStation;
                        return false;
                    }
                }
            }
            else // if station selling
            {
                if (lot.CountAvailable == 0)
                {
                    error = TradingResult.ErrorNotEnoughItemsOnStation;
                    return false;
                }

                // ensure player has enough money to pay for these items
                if (!character.ContainsItemsOfType(
                        ProtoItemCoinPenny.Value,
                        requiredCount: lot.PriceCoinPenny)
                    || !character.ContainsItemsOfType(
                        ProtoItemCoinShiny.Value,
                        requiredCount: lot.PriceCoinShiny))
                {
                    error = TradingResult.ErrorNotEnoughMoneyOnPlayer;
                    return false;
                }
            }

            // no error
            error = TradingResult.Success;
            return true;
        }
    }
}