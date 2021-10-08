namespace AtomicTorch.CBND.CoreMod.StaticObjects.Structures.TradingStations
{
    using AtomicTorch.CBND.CoreMod.ClientComponents.Rendering.Lighting;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.CoreMod.Systems.Construction;
    using AtomicTorch.CBND.CoreMod.Systems.Physics;
    using AtomicTorch.CBND.CoreMod.Systems.TradingStations;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Items;
    using AtomicTorch.CBND.GameApi.Data.World;
    using AtomicTorch.CBND.GameApi.Scripting;
    using AtomicTorch.CBND.GameApi.ServicesClient.Components;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AtomicTorch.CBND.CoreMod.Items;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects;
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
    using AtomicTorch.CBND.GameApi.Scripting.Network;
    using AtomicTorch.CBND.GameApi.ServicesServer;
    using AtomicTorch.GameEngine.Common.Extensions;

    public class ObjectNpcTradingStation : ProtoObjectTradingStation
    {
        public override string Description =>
            "NPC Trading station";

        public override byte LotsCount => 6;

        public override string Name => "Large trading station";

        public override ObjectMaterial ObjectMaterial => ObjectMaterial.Metal;

        public override double ObstacleBlockDamageCoef => 1;

        public override byte StockItemsContainerSlotsCount => 24;

        public override double StructureExplosiveDefenseCoef => 0.25;

        public override float StructurePointsMax => 350000;

        protected override BaseClientComponentLightSource ClientCreateLightSource(IClientSceneObject sceneObject)
        {
            return ClientLighting.CreateLightSourceSpot(
                sceneObject,
                color: LightColors.ElectricCold,
                size: (1, 1),
                positionOffset: (1, 0.6));
        }

        protected override void ServerInitialize(ServerInitializeData data)
        {
            base.ServerInitialize(data);

            var machinegundLvl2 = Api.GetProtoEntity<ItemManualMachinegun300Lvl2>();
            var machinegundLvl3 = Api.GetProtoEntity<ItemManualMachinegun300Lvl3>();
            var machinegundLvl4 = Api.GetProtoEntity<ItemManualMachinegun300Lvl4>();
            var machinegundLvl5 = Api.GetProtoEntity<ItemManualMachinegun300Lvl5>();

            TradingStationsSystem.CallServerRemote_SetTradingLot(data.GameObject as IStaticWorldObject, 0, machinegundLvl2, 5, 5, 1);
            TradingStationsSystem.CallServerRemote_SetTradingLot(data.GameObject as IStaticWorldObject, 1, machinegundLvl3, 5, 5, 1);
            TradingStationsSystem.CallServerRemote_SetTradingLot(data.GameObject as IStaticWorldObject, 2, machinegundLvl4, 5, 5, 1);
            TradingStationsSystem.CallServerRemote_SetTradingLot(data.GameObject as IStaticWorldObject, 3, machinegundLvl5, 5, 5, 1);

            var tradingStationItemsContainer = data.PrivateState.StockItemsContainer;

            Api.Server.Items.CreateItem<ItemManualMachinegun300Lvl2>(container: tradingStationItemsContainer, slotId: 0, count: 5);
            Api.Server.Items.CreateItem<ItemManualMachinegun300Lvl3>(container: tradingStationItemsContainer, slotId: 1, count: 5);
            Api.Server.Items.CreateItem<ItemManualMachinegun300Lvl4>(container: tradingStationItemsContainer, slotId: 2, count: 5);
            Api.Server.Items.CreateItem<ItemManualMachinegun300Lvl5>(container: tradingStationItemsContainer, slotId: 3, count: 5);

        }

        protected override void ClientInitialize(ClientInitializeData data)
        {

            base.ClientInitialize(data);
        }

        protected override void ClientSetupRenderer(IComponentSpriteRenderer renderer)
        {
            base.ClientSetupRenderer(renderer);
            renderer.DrawOrderOffsetY = 0.2;
            renderer.PositionOffset = (0.13, 0);
        }

        protected override void CreateLayout(StaticObjectLayout layout)
        {
            layout.Setup("##");
        }

        protected override void PrepareConstructionConfig(
            ConstructionTileRequirements tileRequirements,
            ConstructionStageConfig build,
            ConstructionStageConfig repair,
            ConstructionUpgradeConfig upgrade,
            out ProtoStructureCategory category)
        {
            category = GetCategory<StructureCategoryOther>();

            build.StagesCount = 10;
            build.StageDurationSeconds = BuildDuration.Short;
            build.AddStageRequiredItem<ItemIngotSteel>(count: 10);
            build.AddStageRequiredItem<ItemGlassRaw>(count: 10);
            build.AddStageRequiredItem<ItemComponentsElectronic>(count: 2);

            repair.StagesCount = 10;
            repair.StageDurationSeconds = BuildDuration.Short;
            repair.AddStageRequiredItem<ItemIngotSteel>(count: 5);
        }

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(ObjectDefensePresets.Tier3);
        }

        protected override void SharedCreatePhysics(CreatePhysicsData data)
        {
            data.PhysicsBody
                //.AddShapeRectangle((1.8, 0.5),  offset: (0.1, 0.05))
                //.AddShapeRectangle((1.7, 0.4),  offset: (0.15, 0.8), group: CollisionGroups.HitboxMelee)
                //.AddShapeRectangle((1.6, 0.2),  offset: (0.2, 0.85), group: CollisionGroups.HitboxRanged)
                .AddShapeRectangle((1.8, 1.25), offset: (0.1, 0.05), group: CollisionGroups.ClickArea);
        }
    }
}