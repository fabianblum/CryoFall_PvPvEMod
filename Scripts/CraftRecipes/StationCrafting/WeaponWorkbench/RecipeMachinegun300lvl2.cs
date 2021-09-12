namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeMachinegun300lvl2 : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectWeaponWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemMachinegun300>(count: 1);
            inputItems.Add<ItemManualMachinegun300Lvl2>(count: 1);

            outputItems.Add<ItemMachinegun300lvl2>();
        }
    }
}