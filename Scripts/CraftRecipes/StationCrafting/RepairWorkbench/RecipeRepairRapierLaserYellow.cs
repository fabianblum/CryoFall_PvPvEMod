namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Melee;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairRapierLaserYellow : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemIngotCopper>(count: 13);
            inputItems.Add<ItemPlastic>(count: 10);
            inputItems.Add<ItemComponentsOptical>(count: 5);
            inputItems.Add<ItemOrePragmium>(count: 5);
			inputItems.Add<ItemDuctTape>(count: 3);
            inputItems.Add<ItemRapierLaserYellow>(count: 1);

            outputItems.Add<ItemRapierLaserYellow>();
        }
    }
}