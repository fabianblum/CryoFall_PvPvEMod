namespace AtomicTorch.CBND.CoreMod.Technologies.Tier3.Defense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeMetalArmor : TechNode<TechGroupDefenseT3>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeMetalArmor>()
                  .AddRecipe<RecipeMetalArmorlvl2>()
                  .AddRecipe<RecipeMetalArmorlvl3>()
                  .AddRecipe<RecipeMetalArmorlvl4>()
                  .AddRecipe<RecipeMetalArmorlvl5>()
                  .AddRecipe<RecipeRepairMetalArmor>();
        }
    }
}