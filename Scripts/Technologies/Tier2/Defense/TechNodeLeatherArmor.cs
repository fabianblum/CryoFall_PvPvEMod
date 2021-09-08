namespace AtomicTorch.CBND.CoreMod.Technologies.Tier2.Defense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeLeatherArmor : TechNode<TechGroupDefenseT2>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeLeatherArmor>()
                  .AddRecipe<RecipeLeatherArmorlvl2>()
                  .AddRecipe<RecipeLeatherArmorlvl3>()
                  .AddRecipe<RecipeLeatherArmorlvl4>()
                  .AddRecipe<RecipeLeatherArmorlvl5>()
                  .AddRecipe<RecipeRepairLeatherArmor>();

            config.SetRequiredNode<TechNodeQuiltedHeadgear>();
        }
    }
}