﻿namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeMachinePistollvl5 : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectWeaponWorkbench>();

            duration = CraftingDuration.Long;

            inputItems.Add<ItemMachinePistollvl4>(count: 1);
            inputItems.Add<ItemIngotSteel>(count: 5);
            inputItems.Add<ItemIngotCopper>(count: 3);
            inputItems.Add<ItemRubberVulcanized>(count: 2);
            inputItems.Add<ItemManualMachinePistolLvl5>(count: 1);

            outputItems.Add<ItemMachinePistollvl5>();
        }

        protected override void PrepareOrigin()
        {
            dependOrigins = new List<String>();
            dependOrigins.Add("Trader");
        }
    }
}