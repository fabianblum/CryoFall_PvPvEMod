﻿namespace AtomicTorch.CBND.CoreMod.Technologies.Tier4.Jewelry
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeSteppenHawkGold : TechNode<TechGroupJewelryT4>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeSteppenHawkGold>()
				  .AddRecipe<RecipeRepairSteppenHawkGold>();

            config.SetRequiredNode<TechNodeGoldArmor>();
        }
    }
}