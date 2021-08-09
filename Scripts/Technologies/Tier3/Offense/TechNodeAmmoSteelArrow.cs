namespace AtomicTorch.CBND.CoreMod.Technologies.Tier3.Offense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeAmmoSteelArrow : TechNode<TechGroupOffenseT3>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeSteelArrow>()
                  .AddRecipe<RecipeSteelArrowBH>()
                  .AddRecipe<RecipeSteelArrowEX>()
                  .AddRecipe<RecipeSteelArrowTX>();
        }
    }
}