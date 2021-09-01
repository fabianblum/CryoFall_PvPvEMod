namespace AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Skills;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Loot;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Farms;
    using AtomicTorch.CBND.CoreMod.Systems.Droplists;
    using AtomicTorch.CBND.CoreMod.Systems.Physics;
    using AtomicTorch.CBND.GameApi.Data.World;
    using AtomicTorch.CBND.GameApi.Resources;
    using AtomicTorch.CBND.GameApi.ServicesClient.Components;
    using AtomicTorch.GameEngine.Common.Primitives;

    public class ObjectPlantMushroomRust : ProtoObjectPlant
    {
        public override string Name => "Rust Mushroom";

        public override byte NumberOfHarvests => 1;

        public override double ObstacleBlockDamageCoef => 0.5;

        public override float StructurePointsMax => 25;

        protected override bool CanFlipSprite => false;

        protected override TimeSpan TimeToGiveHarvest { get; } = TimeSpan.FromHours(1);

        protected override TimeSpan TimeToMature { get; } = TimeSpan.FromHours(3);

        public override Vector2D SharedGetObjectCenterWorldOffset(IWorldObject worldObject)
            => (0.5, 0.2);

        protected override void ClientInitialize(ClientInitializeData data)
        {
            base.ClientInitialize(data);

            var protoFarm = CommonGetFarmObjectProto(data.GameObject.OccupiedTile);
            if (!(protoFarm is ObjectPlantPot))
            {
                data.ClientState.Renderer.DrawOrderOffsetY += 0.5;
            }
        }

        protected override void ClientSetupRenderer(IComponentSpriteRenderer renderer)
        {
            base.ClientSetupRenderer(renderer);
            ClientGrassRenderingHelper.Setup(renderer,
                                             power: 0.1f,
                                             pivotY: 0.5f);
        }

        protected override ITextureResource PrepareDefaultTexture(Type thisType)
        {
            return new TextureAtlasResource(
                base.PrepareDefaultTexture(thisType),
                columns: 4,
                rows: 1);
        }

        protected override void PrepareGatheringDroplist(DropItemsList droplist)
        {
            droplist.Add<ItemMushroomRust>(count: 2, countRandom: 2);

            // additional yield
            droplist.Add<ItemMushroomRust>(count: 2, condition: ItemFertilizer.ConditionExtraYield);
            droplist.Add<ItemMushroomRust>(count: 1, condition: SkillFarming.ConditionExtraYield, probability: 0.05f);
        }
        protected override void SharedCreatePhysics(CreatePhysicsData data)
        {
            data.PhysicsBody
                .AddShapeRectangle(
                    offset: (0.25, 0.2),
                    size: (0.5, 0.6),
                    group: CollisionGroups.HitboxMelee)
                .AddShapeRectangle(
                    offset: (0.25, 0.2),
                    size: (0.5, 0.6),
                    group: CollisionGroups.HitboxRanged)
                .AddShapeCircle(
                    radius: 0.45,
                    center: (0.5, 0.5),
                    group: CollisionGroups.ClickArea);
        }
    }
}