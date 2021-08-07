namespace AtomicTorch.CBND.CoreMod.Technologies.Tier1.Industry
{
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeRepairWorkbench : TechNode<TechGroupIndustryT1>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddStructure<ObjectRepairWorkbench>()
                  .AddRecipe<RecipeRepairAxeIron>()
                  .AddRecipe<RecipeRepairAxeSteel>();

            config.SetRequiredNode<TechNodeCrowbar>();
        }
    }
}