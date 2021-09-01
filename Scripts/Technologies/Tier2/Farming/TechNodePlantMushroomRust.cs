namespace AtomicTorch.CBND.CoreMod.Technologies.Tier2.Farming
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodePlantMushroomRust : TechNode<TechGroupFarmingT2>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeSeedsMushroomRust>();

            config.SetRequiredNode<TechNodePlantBerriesViolet>();
        }
    }
}