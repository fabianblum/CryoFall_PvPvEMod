﻿namespace AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Trees
{
    using System;
	using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Seeds;
    using AtomicTorch.CBND.CoreMod.Skills;
    using AtomicTorch.CBND.CoreMod.Systems.Droplists;
    using AtomicTorch.CBND.CoreMod.Systems.LandClaim;
    using AtomicTorch.CBND.GameApi.Data.World;
    using AtomicTorch.CBND.GameApi.Resources;
	using AtomicTorch.CBND.CoreMod.Helpers.Client;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.GameApi.ServicesClient.Components;

    public class ObjectTreeCactus : ProtoObjectTree
    {
        public override string Name => "Cactus";

        public override ObjectMaterial ObjectMaterial => ObjectMaterial.HardTissues;

        public override double TreeHeight => 1.95;

        protected override TimeSpan TimeToMature => TimeSpan.FromHours(3);

        public override byte ClientGetTextureAtlasColumn(
            IStaticWorldObject worldObject,
            VegetationPublicState publicState)
        {
            var growthStage = publicState.GrowthStage;
            if (growthStage == this.GrowthStagesCount)
            {
                // full grown - select one of two variants based on position
                return (byte)(growthStage
                              + PositionalRandom.Get(worldObject.TilePosition, 0, 2, seed: 90139875u));
            }

            return growthStage;
        }

        protected override byte CalculateGrowthStagesCount()
        {
            // last column is not a growth stage - is just another variant of texture (several variations of fully grown plant).
            return (byte)(base.CalculateGrowthStagesCount() - 1);
        }

        protected override void ClientSetupRenderer(IComponentSpriteRenderer renderer)
        {
            base.ClientSetupRenderer(renderer);
            renderer.DrawOrderOffsetY = 0.4;
        }

        protected override ITextureResource PrepareDefaultTexture(Type thisType)
        {
            return new TextureAtlasResource(
                base.PrepareDefaultTexture(thisType),
                columns: 4,
                rows: 1);
        }

        protected override void PrepareDroplistOnDestroy(DropItemsList droplist)
        {
            // primary drop
            droplist
                .Add<ItemCactusFlesh>(count: 2, countRandom: 1);
				
				
			// saplings drop (requires skill)
            droplist
                .Add<ItemSaplingCactustree>(condition: SkillLumbering.ConditionGetSapplings,
                                            count: 1,
                                            probability: 0.15)
                .Add<ItemSaplingCactustree>(condition: SkillLumbering.ConditionGetExtraSapplings,
                                            count: 1,
                                            probability: 0.15);
        }
    }
}