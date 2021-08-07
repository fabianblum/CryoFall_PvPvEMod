namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairHelmetNightVisionAdvanced : Recipe.RecipeForStationCrafting
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

            inputItems.Add<ItemIngotSteel>(count: 7);
            inputItems.Add<ItemPlastic>(count: 7);
            inputItems.Add<ItemComponentsElectronic>(count: 5);
            inputItems.Add<ItemBallisticPlate>(count: 1);
			inputItems.Add<ItemGlue>(count: 2);
			inputItems.Add<ItemHelmetNightVisionAdvanced>(count: 1);

            outputItems.Add<ItemHelmetNightVisionAdvanced>();
        }
    }
}