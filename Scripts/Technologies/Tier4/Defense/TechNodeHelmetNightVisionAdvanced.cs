namespace AtomicTorch.CBND.CoreMod.Technologies.Tier4.Defense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeHelmetNightVisionAdvanced : TechNode<TechGroupDefenseT4>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeHelmetNightVisionAdvanced>()
				  .AddRecipe<RecipeRepairHelmetNightVisionAdvanced>();

            config.SetRequiredNode<TechNodeAssaultArmor>();
        }
    }
}