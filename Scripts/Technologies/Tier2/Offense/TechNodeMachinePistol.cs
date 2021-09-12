namespace AtomicTorch.CBND.CoreMod.Technologies.Tier2.Offense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeMachinePistol : TechNode<TechGroupOffenseT2>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeMachinePistol>()
                  .AddRecipe<RecipeMachinePistollvl2>()
                  .AddRecipe<RecipeMachinePistollvl3>()
                  .AddRecipe<RecipeMachinePistollvl4>()
                  .AddRecipe<RecipeMachinePistollvl5>()
                  .AddRecipe<RecipeRepairMachinePistol>();

            config.SetRequiredNode<TechNodeShotgunDoublebarreled>();
        }
    }
}