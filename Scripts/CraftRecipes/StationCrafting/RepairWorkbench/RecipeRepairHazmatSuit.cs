namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment.Hazmat;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairHazmatSuit : Recipe.RecipeForStationCrafting
    {
        public override bool IsAutoUnlocked => false;

        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.Long;
			
			//Initial Item Cost.
			inputItems.Add<ItemHazmatSuit>();

            inputItems.Add<ItemIngotSteel>(count: 5);
            inputItems.Add<ItemAramidFiber>(count: 5);
            inputItems.Add<ItemTarpaulin>(count: 20);
            inputItems.Add<ItemComponentsElectronic>(count: 7);			
			inputItems.Add<ItemGlue>(count: 1);

            outputItems.Add<ItemHazmatSuit>();
        }
    }
}