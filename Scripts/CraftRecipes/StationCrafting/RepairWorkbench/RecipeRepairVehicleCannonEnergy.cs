namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Vehicle;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;
    using System;

    public class RecipeRepairVehicleCannonEnergy : Recipe.RecipeForStationCrafting
    {
        public override bool IsAutoUnlocked => false;

        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemIngotSteel>(count: 25);
            inputItems.Add<ItemPlastic>(count: 25);
            inputItems.Add<ItemComponentsHighTech>(count: 10);
            inputItems.Add<ItemComponentsOptical>(count: 10);
			inputItems.Add<ItemCanisterMineralOil>(count: 5);
			inputItems.Add<ItemVehicleCannonEnergy>();

            outputItems.Add<ItemVehicleCannonEnergy>();
        }
    }
}