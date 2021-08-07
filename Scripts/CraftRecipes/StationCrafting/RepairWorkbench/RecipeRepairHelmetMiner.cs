namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairHelmetMiner : Recipe.RecipeForStationCrafting
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
			inputItems.Add<ItemHelmetMiner>();

            inputItems.Add<ItemIngotCopper>(count: 5);
            inputItems.Add<ItemLeather>(count: 5);
            inputItems.Add<ItemWire>(count: 5);
            inputItems.Add<ItemGlassRaw>(count: 5);			
			inputItems.Add<ItemGlue>(count: 1);
			
            outputItems.Add<ItemHelmetMiner>();
        }
    }
}