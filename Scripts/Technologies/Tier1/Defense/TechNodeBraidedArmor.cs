namespace AtomicTorch.CBND.CoreMod.Technologies.Tier1.Defense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;

    public class TechNodeBraidedArmor : TechNode<TechGroupDefenseT1>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeBraidedArmor>()
                  .AddRecipe<RecipeBraidedHelmet>()
                  .AddRecipe<RecipeRepairBraidedArmor>()
                  .AddRecipe<RecipeRepairBraidedHelmet>()
                  .AddStructure<ObjectArmorerWorkbench>();

            config.SetRequiredNode<TechNodeGlueFromBones>();
        }
    }
}