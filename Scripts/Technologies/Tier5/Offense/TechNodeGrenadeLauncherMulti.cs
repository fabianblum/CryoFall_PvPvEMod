namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.Offense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;
    using System.Collections.Generic;

    public class TechNodeGrenadeLauncherMulti : TechNode<TechGroupOffenseT5>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeGrenadeLauncherMulti>()
				  .AddRecipe<RecipeRepairGrenadeLauncherMulti>();

            config.SetRequiredNode<TechNodeAmmoGrenadeFreeze>();
        }

        protected void PrepareOrigin()
        {
            dependOrigins = new List<string>();
            dependOrigins.Add("Trader");
        }
    }
}