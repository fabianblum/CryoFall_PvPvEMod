﻿namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeMachinePistollvl3 : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectWeaponWorkbench>();

            duration = CraftingDuration.Long;

            inputItems.Add<ItemMachinePistollvl2>(count: 1);
            inputItems.Add<ItemIngotSteel>(count: 5);
            inputItems.Add<ItemIngotCopper>(count: 3);
            inputItems.Add<ItemRubberVulcanized>(count: 2);
            inputItems.Add<ItemManualMachinePistolLvl3>(count: 1);

            outputItems.Add<ItemMachinePistollvl3>();
        }
    }
}