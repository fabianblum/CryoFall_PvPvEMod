namespace AtomicTorch.CBND.CoreMod.Technologies.Tier3.Defense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeMilitaryHeadgear : TechNode<TechGroupDefenseT3>
    {
		protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeMilitaryHelmet>()
                  .AddRecipe<RecipeMilitaryHelmetlvl2>()
                  .AddRecipe<RecipeMilitaryHelmetlvl3>()
                  .AddRecipe<RecipeMilitaryHelmetlvl4>()
                  .AddRecipe<RecipeMilitaryHelmetlvl5>()
                  .AddRecipe<RecipeRepairMilitaryHelmet>();

            config.SetRequiredNode<TechNodeMilitaryArmor>();
        }
    }
}