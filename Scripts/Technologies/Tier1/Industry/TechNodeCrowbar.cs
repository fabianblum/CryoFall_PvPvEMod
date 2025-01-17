﻿namespace AtomicTorch.CBND.CoreMod.Technologies.Tier1.Industry
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeCrowbar : TechNode<TechGroupIndustryT1>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeCrowbar>()
                  .AddRecipe<RecipeRepairCrowbar>();

            config.SetRequiredNode<TechNodeIronTools>();
        }
    }
}