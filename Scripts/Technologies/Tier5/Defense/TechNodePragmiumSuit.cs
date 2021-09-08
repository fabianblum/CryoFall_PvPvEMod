namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.Defense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodePragmiumSuit : TechNode<TechGroupDefenseT5>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipePragmiumSuit>()
                  .AddRecipe<RecipePragmiumSuitlvl2>()
                  .AddRecipe<RecipePragmiumSuitlvl3>()
                  .AddRecipe<RecipePragmiumSuitlvl4>()
                  .AddRecipe<RecipePragmiumSuitlvl5>()
                  .AddRecipe<RecipeRepairPragmiumSuit>();
        }
    }
}