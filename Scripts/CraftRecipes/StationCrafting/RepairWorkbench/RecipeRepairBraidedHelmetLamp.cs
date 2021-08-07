namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
	using AtomicTorch.CBND.CoreMod.Items.Equipment.Braided;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
	using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.Items.Tools;
    using AtomicTorch.CBND.CoreMod.Items.Tools.Lights;	
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairBraidedHelmetLamp : Recipe.RecipeForStationCrafting
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
			inputItems.Add<ItemBraidedHelmetLamp>();
			
			//Half Braided Helmet Cost.
            inputItems.Add<ItemRope>(count: 2);
			inputItems.Add<ItemThread>(count: 5);
			inputItems.Add<ItemFibers>(count: 5);			
			inputItems.Add<ItemGlue>(count: 1);
			//Half Oil Lamp Cost.
			inputItems.Add<ItemIngotCopper>();
			inputItems.Add<ItemOreCopper>(count: 2);
			inputItems.Add<ItemGlassRaw>(count: 5);
			
            outputItems.Add<ItemBraidedHelmetLamp>();
			outputItems.Add<ItemBottleEmpty>();
        }
    }
}