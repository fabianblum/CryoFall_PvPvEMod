namespace AtomicTorch.CBND.CoreMod.Technologies.Tier4.EnergyWeapons
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeLaserRifle : TechNode<TechGroupEnergyWeaponsT4>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeLaserRifle>()
                  .AddRecipe<RecipeRepairLaserRifle>();

            config.SetRequiredNode<TechNodeLaserPistol>();
        }
    }
}