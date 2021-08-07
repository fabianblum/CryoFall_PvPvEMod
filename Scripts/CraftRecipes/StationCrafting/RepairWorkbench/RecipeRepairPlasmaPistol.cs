namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairPlasmaPistol : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemIngotCopper>(count: 100);
            inputItems.Add<ItemPlastic>(count: 25);
            inputItems.Add<ItemComponentsOptical>(count: 5);
            inputItems.Add<ItemComponentsHighTech>(count: 3);
			inputItems.Add<ItemDuctTape>(count: 2);
            inputItems.Add<ItemPlasmaPistol>(count: 1);

            outputItems.Add<ItemPlasmaPistol>();
        }
    }
}