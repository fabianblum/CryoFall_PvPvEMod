﻿namespace AtomicTorch.CBND.CoreMod.Technologies.Tier2.Fishing
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeFishingRod : TechNode<TechGroupFishingT2>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeFishingRod>()
				  .AddRecipe<RecipeRepairFishingRod>();
        }
    }
}