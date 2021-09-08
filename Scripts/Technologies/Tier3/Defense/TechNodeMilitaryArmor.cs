namespace AtomicTorch.CBND.CoreMod.Technologies.Tier3.Defense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeMilitaryArmor : TechNode<TechGroupDefenseT3>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeMilitaryArmor>()
                  .AddRecipe<RecipeMilitaryArmorlvl2>()
                  .AddRecipe<RecipeMilitaryArmorlvl3>()
                  .AddRecipe<RecipeMilitaryArmorlvl4>()
                  .AddRecipe<RecipeMilitaryArmorlvl5>()
                  .AddRecipe<RecipeRepairMilitaryArmor>();

            config.SetRequiredNode<TechNodeMetalHeadgear>();
        }
    }
}