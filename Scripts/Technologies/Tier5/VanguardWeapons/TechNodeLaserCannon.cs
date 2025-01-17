﻿namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.VanguardWeapons
{
    using AtomicTorch.CBND.CoreMod.CharacterOrigins;
    using AtomicTorch.CBND.CoreMod.CraftRecipes;
    using System.Collections.Generic;

    public class TechNodeLaserCannon : TechNode<TechGroupVanguardWeaponsT5>
    {

        protected override void PrepareTechNode(Config config)
        {
            config.Effects
                  .AddRecipe<RecipeLaserCannon>();


            //config.SetRequiredNode<TechNodeLaserBeam>(); // We will add special components for this weapons later
        }

        protected void PrepareOrigin()
        {
            dependOrigins = new List<string>();
            dependOrigins.Add("Trader");
        }
    }
}