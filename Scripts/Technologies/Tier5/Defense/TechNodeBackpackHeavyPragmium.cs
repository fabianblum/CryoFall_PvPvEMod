namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.Defense
{
  using AtomicTorch.CBND.CoreMod.CraftRecipes;
    using System.Collections.Generic;

    public class TechNodeBackpackHeavyPragmium : TechNode<TechGroupDefenseT5>
  {
    protected override void PrepareTechNode(Config config)
    {
      config.Effects
              .AddRecipe<RecipeBackpackHeavyPragmium>();

      config.SetRequiredNode<TechNodeSuperHeavySuit>();
    }

        protected void PrepareOrigin()
        {
            dependOrigins = new List<string>();
            dependOrigins.Add("Trader");
        }
    }
}