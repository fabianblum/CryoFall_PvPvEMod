namespace AtomicTorch.CBND.CoreMod.Technologies.Tier4.Offense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeSteppenHawk : TechNode<TechGroupOffenseT4>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeSteppenHawk>()
                  .AddRecipe<RecipeRepairSteppenHawk>();

            config.SetRequiredNode<TechNodeAmmo50SH>();
        }
    }
}