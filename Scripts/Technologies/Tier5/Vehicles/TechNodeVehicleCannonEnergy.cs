﻿namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.Vehicles
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeVehicleCannonEnergy : TechNode<TechGroupVehiclesT5>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeVehicleCannonEnergy>()
				  .AddRecipe<RecipeRepairVehicleCannonEnergy>();

            config.SetRequiredNode<TechNodeBehemoth>();
        }
    }
}