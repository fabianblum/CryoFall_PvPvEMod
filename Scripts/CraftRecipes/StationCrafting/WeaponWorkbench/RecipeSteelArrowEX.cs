﻿namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Ammo;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeSteelArrowEX : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectWeaponWorkbench>();

            duration = CraftingDuration.VeryShort;

            inputItems.Add<ItemIngotSteel>(count: 1);
            inputItems.Add<ItemPlastic>(count: 1);
            inputItems.Add<ItemIngotCopper>(count: 10);
            inputItems.Add<ItemBlackpowder>(count: 50);
            inputItems.Add<ItemPaper>(count: 50);
            outputItems.Add<ItemAmmoArrowEX>(count: 10);
        }
    }
}