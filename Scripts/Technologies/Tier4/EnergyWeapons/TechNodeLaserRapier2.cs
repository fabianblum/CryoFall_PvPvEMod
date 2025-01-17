﻿namespace AtomicTorch.CBND.CoreMod.Technologies.Tier4.EnergyWeapons
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeLaserRapier2 : TechNode<TechGroupEnergyWeaponsT4>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeRapierLaserPurple>()
                  .AddRecipe<RecipeRapierLaserYellow>()
                  .AddRecipe<RecipeRepairRapierLaserPurple>()
                  .AddRecipe<RecipeRepairRapierLaserYellow>();

            config.SetRequiredNode<TechNodeLaserRapier1>();
        }
    }
}