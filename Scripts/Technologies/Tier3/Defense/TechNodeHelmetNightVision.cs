namespace AtomicTorch.CBND.CoreMod.Technologies.Tier3.Defense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeHelmetNightVision : TechNode<TechGroupDefenseT3>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeHelmetNightVision>()
				  .AddRecipe<RecipeRepairHelmetNightVision>();

            config.SetRequiredNode<TechNodeMilitaryArmor>();
        }
    }
}