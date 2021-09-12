namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeMilitaryArmorlvl5 : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectArmorerWorkbench>();

            duration = CraftingDuration.Medium;

            inputItems.Add<ItemMilitaryArmorlvl4>(count: 1);
            inputItems.Add<ItemIngotSteel>(count: 7);
            inputItems.Add<ItemThread>(count: 8);
            inputItems.Add<ItemTarpaulin>(count: 7);
            inputItems.Add<ItemGlue>(count: 1);
            inputItems.Add<ItemManualMilitaryArmorLvl5>(count: 1);

            outputItems.Add<ItemMilitaryArmorlvl5>();
        }
    }
}