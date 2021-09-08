namespace AtomicTorch.CBND.CoreMod.Technologies.Tier2.Defense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeLeatherHeadgear : TechNode<TechGroupDefenseT2>
    {
        public override string Name => "Leather headgear";

        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeLeatherHelmetCowboylvl2>()
                  .AddRecipe<RecipeLeatherHelmetCowboylvl2>()
                  .AddRecipe<RecipeLeatherHelmetCowboylvl3>()
                  .AddRecipe<RecipeLeatherHelmetCowboylvl4>()
                  .AddRecipe<RecipeLeatherHelmetCowboylvl5>()
                  .AddRecipe<RecipeLeatherHelmetPilot>()
                  .AddRecipe<RecipeLeatherHelmetPilotlvl2>()
                  .AddRecipe<RecipeLeatherHelmetPilotlvl3>()
                  .AddRecipe<RecipeLeatherHelmetPilotlvl4>()
                  .AddRecipe<RecipeLeatherHelmetPilotlvl5>()
                  .AddRecipe<RecipeLeatherHelmetTricorne>()
                  .AddRecipe<RecipeLeatherHelmetTricornelvl2>()
                  .AddRecipe<RecipeLeatherHelmetTricornelvl3>()
                  .AddRecipe<RecipeLeatherHelmetTricornelvl4>()
                  .AddRecipe<RecipeLeatherHelmetTricornelvl5>()
                  .AddRecipe<RecipeRepairLeatherHelmetCowboy>()
                  .AddRecipe<RecipeRepairLeatherHelmetPilot>()
                  .AddRecipe<RecipeRepairLeatherHelmetTricorne>();

            config.SetRequiredNode<TechNodeLeatherArmor>();
        }
    }
}