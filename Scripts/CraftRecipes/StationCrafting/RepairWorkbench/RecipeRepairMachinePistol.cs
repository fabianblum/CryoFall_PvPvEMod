namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairMachinePistol : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.Long;

            inputItems.Add<ItemIngotSteel>(count: 13);
            inputItems.Add<ItemIngotCopper>(count: 5);
            inputItems.Add<ItemRubberVulcanized>(count: 1);
			inputItems.Add<ItemDuctTape>(count: 1);
            inputItems.Add<ItemMachinePistol>(count: 1);

            outputItems.Add<ItemMachinePistol>();
        }
    }
}