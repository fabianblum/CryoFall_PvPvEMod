namespace AtomicTorch.CBND.CoreMod.Technologies.Tier3.Farming
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodePlantCoffee : TechNode<TechGroupFarmingT3>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeSeedsCoffee>();

            config.SetRequiredNode<TechNodePlantMushroomPink>();
        }
    }
}