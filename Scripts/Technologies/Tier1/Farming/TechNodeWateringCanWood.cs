namespace AtomicTorch.CBND.CoreMod.Technologies.Tier1.Farming
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeWateringCanWood : TechNode<TechGroupFarmingT1>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeWateringCanWood>()
				  .AddRecipe<RecipeRepairWateringCanWood>();

            config.SetRequiredNode<TechNodeFarmingBasics>();
        }
    }
}