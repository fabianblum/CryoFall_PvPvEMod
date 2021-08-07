namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairSteppenHawkGold : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.Long;

            inputItems.Add<ItemIngotSteel>(count: 10);
			inputItems.Add<ItemComponentsWeapon>(count: 2);
			inputItems.Add<ItemIngotGold>(count: 3);
			inputItems.Add<ItemDuctTape>(count: 2);
            inputItems.Add<ItemSteppenHawkGold>(count: 1);

            outputItems.Add<ItemSteppenHawkGold>();
        }
    }
}