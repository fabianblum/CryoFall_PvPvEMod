﻿namespace AtomicTorch.CBND.CoreMod.Technologies.Tier1.Defense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeBraidedHelmetLamp : TechNode<TechGroupDefenseT1>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeBraidedHelmetLamp>()
				  .AddRecipe<RecipeRepairBraidedHelmetLamp>();
				  
            config.SetRequiredNode<TechNodeBraidedArmor>();
        }
    }
}