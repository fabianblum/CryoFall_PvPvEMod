namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
	using AtomicTorch.CBND.CoreMod.Items.Equipment;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairClothHat : Recipe.RecipeForStationCrafting
    {
        public override bool IsAutoUnlocked => false;

        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.Short;
			
			//Initial Item Cost.
			inputItems.Add<ItemClothHelmet>();

            inputItems.Add<ItemThread>(count: 1);
			inputItems.Add<ItemFibers>(count: 1);

            outputItems.Add<ItemClothHelmet>();
        }
    }
}