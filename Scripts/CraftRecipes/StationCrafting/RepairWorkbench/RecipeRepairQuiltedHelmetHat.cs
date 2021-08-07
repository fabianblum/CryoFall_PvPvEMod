namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment.Quilted;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
	using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairQuiltedHelmetPadded : Recipe.RecipeForStationCrafting
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

			//Initial Item Cost.
			inputItems.Add<ItemQuiltedHelmetPadded>();

            inputItems.Add<ItemThread>(count: 25);
            inputItems.Add<ItemRope>(count: 2);
			inputItems.Add<ItemFibers>(count: 5);			
			inputItems.Add<ItemGlue>(count: 1);
			
            outputItems.Add<ItemQuiltedHelmetPadded>();
			outputItems.Add<ItemBottleEmpty>();
        }
    }
}