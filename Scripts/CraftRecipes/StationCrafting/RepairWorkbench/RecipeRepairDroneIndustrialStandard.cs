namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using AtomicTorch.CBND.CoreMod.Items.Drones;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;
    using System;

    public class RecipeRepairDroneIndustrialStandard : Recipe.RecipeForStationCrafting
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

            inputItems.Add<ItemIngotSteel>(count: 2);
            inputItems.Add<ItemComponentsElectronic>(count: 3);
            inputItems.Add<ItemPowerCell>(count: 1);
			inputItems.Add<ItemDuctTape>(count: 2);
			inputItems.Add<ItemDroneIndustrialStandard>();

            outputItems.Add<ItemDroneIndustrialStandard>();
        }
    }
}