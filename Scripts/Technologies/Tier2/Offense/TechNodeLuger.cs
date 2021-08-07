namespace AtomicTorch.CBND.CoreMod.Technologies.Tier2.Offense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeLuger : TechNode<TechGroupOffenseT2>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeLuger>()
                  .AddRecipe<RecipeRepairLuger>();

            config.SetRequiredNode<TechNodeShotgunDoublebarreled>();
        }
    }
}