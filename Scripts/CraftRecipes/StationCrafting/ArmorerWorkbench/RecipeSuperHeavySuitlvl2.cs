﻿namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using AtomicTorch.CBND.CoreMod.Items.Equipment.SuperHeavyArmor;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;
    using System;

    public class RecipeSuperHeavySuitlvl2 : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectArmorerWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemSuperHeavySuit>(count: 1);
            inputItems.Add<ItemIngotSteel>(count: 30);
            inputItems.Add<ItemAramidFiber>(count: 7);
            inputItems.Add<ItemKeinite>(count: 7);
            inputItems.Add<ItemComponentsHighTech>(count: 3);
            inputItems.Add<ItemBallisticPlate>(count: 3);
            inputItems.Add<ItemManualSuperHeavySuitLvl2>(count: 1);

            outputItems.Add<ItemSuperHeavySuitlvl2>();
        }
    }
}