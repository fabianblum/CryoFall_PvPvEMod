﻿namespace AtomicTorch.CBND.CoreMod.Technologies.Tier1.Farming
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeWateringCanCopper : TechNode<TechGroupFarmingT1>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeWateringCanCopper>()
				  .AddRecipe<RecipeRepairWateringCanCopper>();

            config.SetRequiredNode<TechNodeWateringCanWood>();
        }
    }
}