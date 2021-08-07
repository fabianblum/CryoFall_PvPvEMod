namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairPlasmaRifle : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemIngotCopper>(count: 125);
            inputItems.Add<ItemPlastic>(count: 38);
            inputItems.Add<ItemComponentsOptical>(count: 10);
            inputItems.Add<ItemComponentsHighTech>(count: 3);
			inputItems.Add<ItemDuctTape>(count: 2);
            inputItems.Add<ItemPlasmaRifle>(count: 1);

            outputItems.Add<ItemPlasmaRifle>();
        }
    }
}