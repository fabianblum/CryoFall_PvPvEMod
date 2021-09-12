namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeMetalHelmetClosedlvl2 : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectArmorerWorkbench>();

            duration = CraftingDuration.Medium;

            inputItems.Add<ItemMetalHelmetClosed>(count: 1);
            inputItems.Add<ItemIngotSteel>(count: 10);
            inputItems.Add<ItemIngotCopper>(count: 5);
            inputItems.Add<ItemManualMetalHelmetClosedLvl2>(count: 1);

            outputItems.Add<ItemMetalHelmetClosedlvl2>();
        }
    }
}