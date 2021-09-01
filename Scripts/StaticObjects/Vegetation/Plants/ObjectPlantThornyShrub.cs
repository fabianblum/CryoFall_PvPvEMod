namespace AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Skills;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Loot;
    using AtomicTorch.CBND.CoreMod.Systems.Droplists;
    using AtomicTorch.CBND.GameApi.Resources;
    using AtomicTorch.CBND.GameApi.ServicesClient.Components;
    using static Systems.Physics.CollisionGroups;

    public class ObjectPlantThornyShrub : ProtoObjectPlant
    {
        public override string Name => "Thorny shrub";

        public override byte NumberOfHarvests => 2;

        public override double ObstacleBlockDamageCoef => 0.5;

        public override float StructurePointsMax => 100;

        protected override bool CanFlipSprite => false;

        protected override TimeSpan TimeToGiveHarvest { get; } = TimeSpan.FromHours(2);

        protected override TimeSpan TimeToMature { get; } = TimeSpan.FromHours(8);

        protected override void ClientSetupRenderer(IComponentSpriteRenderer renderer)
        {
            base.ClientSetupRenderer(renderer);
            renderer.DrawOrderOffsetY = 0.25;

            ClientGrassRenderingHelper.Setup(renderer,
                                             power: 0.1f,
                                             pivotY: 0.2f);
        }

        protected override ITextureResource PrepareDefaultTexture(Type thisType)
        {
            return new TextureAtlasResource(
                base.PrepareDefaultTexture(thisType),
                columns: 3,
                rows: 1);
        }

        protected override void PrepareGatheringDroplist(DropItemsList droplist)
        {
            droplist
                .Add<ItemFibers>(count: 5, countRandom: 5)
                .Add<ItemTwigs>(count: 3, countRandom: 3);

            // additional yield
            droplist
                .Add<ItemFibers>(count: 2, probability: 1 / 5.0, condition: SkillFarming.ConditionExtraYield)
                .Add<ItemTwigs>(count: 1, probability: 1 / 5.0, condition: SkillFarming.ConditionExtraYield);
        }

        protected override void SharedCreatePhysics(CreatePhysicsData data)
        {
            data.PhysicsBody
                .AddShapeRectangle(size: (0.9, 0.7), offset: (0.05, 0.15))
                .AddShapeRectangle(size: (0.9, 0.7),
                                   offset: (0.05, 0.15),
                                   group: HitboxMelee)
                .AddShapeRectangle(size: (0.9, 0.7),
                                   offset: (0.05, 0.15),
                                   group: HitboxRanged)
                .AddShapeCircle(radius: 0.45, center: (0.5, 0.5), group: ClickArea);
        }
    }
}