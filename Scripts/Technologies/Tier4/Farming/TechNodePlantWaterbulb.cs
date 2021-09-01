namespace AtomicTorch.CBND.CoreMod.Technologies.Tier4.Farming
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodePlantWaterbulb : TechNode<TechGroupFarmingT4>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeSeedsWaterbulb>();

            config.SetRequiredNode<TechNodePlantPineapple>();
        }
    }
}