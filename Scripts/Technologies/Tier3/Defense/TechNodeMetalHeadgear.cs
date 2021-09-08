namespace AtomicTorch.CBND.CoreMod.Technologies.Tier3.Defense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeMetalHeadgear : TechNode<TechGroupDefenseT3>
    {

        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeMetalHelmetClosed>()
                  .AddRecipe<RecipeMetalHelmetClosedlvl2>()
                  .AddRecipe<RecipeMetalHelmetClosedlvl3>()
                  .AddRecipe<RecipeMetalHelmetClosedlvl4>()
                  .AddRecipe<RecipeMetalHelmetClosedlvl5>()
                  .AddRecipe<RecipeMetalHelmetSkull>()
                  .AddRecipe<RecipeMetalHelmetSkulllvl2>()
                  .AddRecipe<RecipeMetalHelmetSkulllvl3>()
                  .AddRecipe<RecipeMetalHelmetSkulllvl4>()
                  .AddRecipe<RecipeMetalHelmetSkulllvl5>()
                  .AddRecipe<RecipeMetalHelmetSkulllvl2>()
                  .AddRecipe<RecipeMetalHelmetSkulllvl3>()
                  .AddRecipe<RecipeMetalHelmetSkulllvl4>()
                  .AddRecipe<RecipeMetalHelmetSkulllvl5>()
                  .AddRecipe<RecipeMetalHelmetSkulllvl2>()
                  .AddRecipe<RecipeMetalHelmetSkulllvl3>()
                  .AddRecipe<RecipeMetalHelmetSkulllvl4>()
                  .AddRecipe<RecipeMetalHelmetSkulllvl5>()
                  .AddRecipe<RecipeRepairMetalHelmetClosed>()
                  .AddRecipe<RecipeRepairMetalHelmetSkull>();
				  
            config.SetRequiredNode<TechNodeMetalArmor>();
        }
    }
}