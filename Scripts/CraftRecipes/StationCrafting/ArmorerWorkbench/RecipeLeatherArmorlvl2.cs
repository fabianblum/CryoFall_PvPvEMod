﻿namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeLeatherArmorlvl2 : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectArmorerWorkbench>();

            duration = CraftingDuration.Medium;

            inputItems.Add<ItemLeatherArmor>(count: 1);
            inputItems.Add<ItemLeather>(count: 5);
            inputItems.Add<ItemThread>(count: 2);
            inputItems.Add<ItemGlue>(count: 1);
            inputItems.Add<ItemManualLeatherArmorLvl2>(count: 1);

            outputItems.Add<ItemLeatherArmorlvl2>();
        }
    }
}