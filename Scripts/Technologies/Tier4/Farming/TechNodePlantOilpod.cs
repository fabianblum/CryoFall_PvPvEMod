namespace AtomicTorch.CBND.CoreMod.Technologies.Tier4.Farming
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodePlantOilpod : TechNode<TechGroupFarmingT4>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeSeedsOilpod>();

            config.SetRequiredNode<TechNodePlantWaterbulb>();
        }
    }
}