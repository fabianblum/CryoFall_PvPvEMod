﻿namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairFlintlockPistol : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.Medium;

            inputItems.Add<ItemIngotIron>(count: 5);
            inputItems.Add<ItemIngotCopper>(count: 2);
            inputItems.Add<ItemPlanks>(count: 20);
			inputItems.Add<ItemDuctTape>(count: 1);
            inputItems.Add<ItemFlintlockPistol>(count: 1);

            outputItems.Add<ItemFlintlockPistol>();
        }
    }
}