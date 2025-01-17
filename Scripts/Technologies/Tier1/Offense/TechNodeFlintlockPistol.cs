﻿namespace AtomicTorch.CBND.CoreMod.Technologies.Tier1.Offense
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeFlintlockPistol : TechNode<TechGroupOffenseT1>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeFlintlockPistol>()
                  .AddRecipe<RecipeRepairFlintlockPistol>();

            config.SetRequiredNode<TechNodePaperCartridge>();
        }
    }
}