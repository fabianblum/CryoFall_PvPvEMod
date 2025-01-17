﻿namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeSubMachinegun10mmlvl3 : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectWeaponWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemSubmachinegun10mmlvl2>(count: 1);
            inputItems.Add<ItemIngotSteel>(count: 10);
            inputItems.Add<ItemPlastic>(count: 5);
            inputItems.Add<ItemComponentsWeapon>(count: 1);
            inputItems.Add<ItemManualSubMachinegun10mmLvl3>(count: 1);

            outputItems.Add<ItemSubmachinegun10mmlvl3>();
        }
    }
}