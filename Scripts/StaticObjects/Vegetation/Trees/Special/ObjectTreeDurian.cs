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

    public class ObjectTreeDurian : ProtoObjectTree
    {
        public override string Name => "Durian tree";

        public override double TreeHeight => 2;

        protected override TimeSpan TimeToMature => TimeSpan.FromHours(2);

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
                .Add<ItemLogs>(count: 5)
                .Add<ItemTwigs>(count: 2, countRandom: 2);

            // special drop
            droplist
                .Add<ItemDurian>(count: 1, countRandom: 1);

            // skill drop
            droplist
                .Add<ItemDurian>(count: 1, probability: 1 / 5.0, condition: SkillForaging.ConditionAdditionalYield);
				
				
			// saplings drop (requires skill)
            droplist
                .Add<ItemSaplingDuriantree>(condition: SkillLumbering.ConditionGetSapplings,
                                            count: 1,
                                            probability: 0.15)
                .Add<ItemSaplingDuriantree>(condition: SkillLumbering.ConditionGetExtraSapplings,
                                            count: 1,
                                            probability: 0.15);
        }
    }
}