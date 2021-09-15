namespace AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Bushes
{
    using System;
    using AtomicTorch.CBND.CoreMod.ClientComponents.Rendering.Lighting;
    using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.Skills;
    using AtomicTorch.CBND.CoreMod.Systems.Droplists;
    using AtomicTorch.CBND.CoreMod.Systems.TimeOfDaySystem;
    using AtomicTorch.CBND.GameApi.Data.State;
    using AtomicTorch.CBND.GameApi.Resources;
    using AtomicTorch.CBND.GameApi.ServicesClient.Components;
    using AtomicTorch.CBND.CoreMod.Systems.Physics;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Seeds;

    public class ObjectBushCocaLeaf : ProtoObjectBush
    {
        public override string Name => "Coca Leaf";

        protected override TimeSpan TimeToGiveHarvest => TimeSpan.FromHours(3);

        protected override TimeSpan TimeToMature => TimeSpan.FromHours(2);

        protected override void ClientSetupRenderer(IComponentSpriteRenderer renderer)
        {
            base.ClientSetupRenderer(renderer);
            renderer.Scale = 1f;
            renderer.PositionOffset += (0, -0.08);
            renderer.DrawOrderOffsetY = 0.3;
        }

        protected override ITextureResource PrepareDefaultTexture(Type thisType)
        {
            return new TextureAtlasResource(
                base.PrepareDefaultTexture(thisType),
                columns: 5,
                rows: 1);
        }

        protected override void PrepareGatheringDroplist(DropItemsList droplist)
        {
            droplist
                .Add<ItemCocaLeaf>(count: 3)
                .Add<ItemCocaLeaf>(count: 2,
                                        probability: 1 / 5.0,
                                        condition: SkillForaging.ConditionAdditionalYield);

            // saplings drop (requires skill)
            droplist
                .Add<ItemSeedsCocaine>(condition: SkillLumbering.ConditionGetSapplings,
                                            count: 1,
                                            probability: 0.15)
                .Add<ItemSeedsCocaine>(condition: SkillLumbering.ConditionGetExtraSapplings,
                                            count: 1,
                                            probability: 0.15);
        }

        protected override void SharedCreatePhysics(CreatePhysicsData data)
        {
            data.PhysicsBody
                .AddShapeCircle(
                    radius: 0.39,
                    center: (0.5, 0.42))
                .AddShapeRectangle(
                    size: (0.8, 0.7),
                    offset: (0.1, 0.1),
                    group: CollisionGroups.HitboxMelee)
                .AddShapeRectangle(
                    size: (0.9, 0.8),
                    offset: (0.05, 0.05),
                    group: CollisionGroups.HitboxRanged)
                .AddShapeCircle(
                    radius: 0.4,
                    center: (0.5, 0.5),
                    group: CollisionGroups.ClickArea);
        }
    }
}