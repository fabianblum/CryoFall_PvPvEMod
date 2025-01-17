﻿namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Tools;
    using AtomicTorch.CBND.CoreMod.Items.Tools.Lights;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairFlashlight : Recipe.RecipeForStationCrafting
    {
        public override bool IsAutoUnlocked => false;
		
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.Medium;

            inputItems.Add<ItemIngotSteel>(count: 1);
            inputItems.Add<ItemWire>(count: 1);
            inputItems.Add<ItemGlassRaw>(count: 2);
			inputItems.Add<ItemGlue>(count: 1);
			inputItems.Add<ItemFlashlight>(count: 1);

            outputItems.Add<ItemFlashlight>();
        }
    }
}