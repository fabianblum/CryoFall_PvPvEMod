namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
	using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairMilitaryHelmet : Recipe.RecipeForStationCrafting
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
			inputItems.Add<ItemMilitaryHelmetlvl2>();

            inputItems.Add<ItemIngotSteel>(count: 10);
            inputItems.Add<ItemThread>(count: 12);
            inputItems.Add<ItemTarpaulin>(count: 10);			
			inputItems.Add<ItemGlue>(count: 2);

            outputItems.Add<ItemMilitaryHelmetlvl2>();
			outputItems.Add<ItemBottleEmpty>();
        }
    }
}