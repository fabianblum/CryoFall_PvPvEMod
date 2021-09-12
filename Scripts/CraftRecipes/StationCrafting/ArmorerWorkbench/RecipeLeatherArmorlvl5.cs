namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Equipment;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeLeatherArmorlvl5 : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectArmorerWorkbench>();

            duration = CraftingDuration.Medium;

            inputItems.Add<ItemLeatherArmorlvl4>(count: 1);
            inputItems.Add<ItemManualLeatherArmorLvl5>(count: 1);

            outputItems.Add<ItemLeatherArmorlvl5>();
        }

        protected override void PrepareOrigin()
        {
            dependOrigins = new List<String>();
            dependOrigins.Add("Trader");
        }
    }
}