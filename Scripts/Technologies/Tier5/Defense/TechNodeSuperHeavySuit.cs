namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.Defense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;
    using System.Collections.Generic;

    public class TechNodeSuperHeavySuit : TechNode<TechGroupDefenseT5>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeSuperHeavySuit>()
                  .AddRecipe<RecipeSuperHeavySuitlvl2>()
                  .AddRecipe<RecipeSuperHeavySuitlvl3>()
                  .AddRecipe<RecipeSuperHeavySuitlvl4>()
                  .AddRecipe<RecipeSuperHeavySuitlvl5>()
                  .AddRecipe<RecipeRepairSuperHeavySuit>();

            config.SetRequiredNode<TechNodePragmiumSuit>();
        }

        protected void PrepareOrigin()
        {
            dependOrigins = new List<string>();
            dependOrigins.Add("Trader");
        }
    }
}