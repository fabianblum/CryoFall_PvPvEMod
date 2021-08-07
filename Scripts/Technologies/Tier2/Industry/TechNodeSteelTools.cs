namespace AtomicTorch.CBND.CoreMod.Technologies.Tier2.Industry
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeSteelTools : TechNode<TechGroupIndustryT2>
    {
        public override string Name => "Steel tools";

        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeAxeSteel>()
                  .AddRecipe<RecipePickaxeSteel>()
                  .AddRecipe<RecipeToolboxT3>()
                  .AddRecipe<RecipeRepairAxeSteel>()
                  .AddRecipe<RecipeRepairPickaxeSteel>()
				  .AddRecipe<RecipeRepairToolboxT3>();

            config.SetRequiredNode<TechNodeSteelSmelting>();
        }
    }
}