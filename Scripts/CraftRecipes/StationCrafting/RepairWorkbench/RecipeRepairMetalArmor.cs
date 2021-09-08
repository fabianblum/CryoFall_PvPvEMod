namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
	using AtomicTorch.CBND.CoreMod.Items.Equipment;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairMetalArmor : Recipe.RecipeForStationCrafting
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
			inputItems.Add<ItemMetalArmorlvl2>();

            inputItems.Add<ItemIngotIron>(count: 5);
            inputItems.Add<ItemRubberVulcanized>(count: 2);
            inputItems.Add<ItemCharcoal>(count: 12);			
			inputItems.Add<ItemCement>(count: 5);

            outputItems.Add<ItemMetalArmorlvl2>();
        }
    }
}