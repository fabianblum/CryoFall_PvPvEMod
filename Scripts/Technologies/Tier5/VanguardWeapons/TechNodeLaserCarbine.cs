namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.VanguardWeapons
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;
    using System.Collections.Generic;

    public class TechNodeLaserCarbine : TechNode<TechGroupVanguardWeaponsT5>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeLaserCarbine>();

            //config.SetRequiredNode<TechNodeLaserWeapons>(); // We will add special components for this weapons later
        }

        protected void PrepareOrigin()
        {
            dependOrigins = new List<string>();
            dependOrigins.Add("Trader");
        }
    }
}