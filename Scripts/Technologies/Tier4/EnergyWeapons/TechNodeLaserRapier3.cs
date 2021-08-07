namespace AtomicTorch.CBND.CoreMod.Technologies.Tier4.EnergyWeapons
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeLaserRapier3 : TechNode<TechGroupEnergyWeaponsT4>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeRapierLaserGreen>()
                  .AddRecipe<RecipeRapierLaserRed>()
                  .AddRecipe<RecipeRapierLaserBlue>()
                  .AddRecipe<RecipeRepairRapierLaserGreen>()
                  .AddRecipe<RecipeRepairRapierLaserRed>()
                  .AddRecipe<RecipeRepairRapierLaserBlue>();

            config.SetRequiredNode<TechNodeLaserRapier2>();
        }
    }
}