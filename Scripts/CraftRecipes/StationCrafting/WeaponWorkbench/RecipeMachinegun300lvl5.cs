namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeMachinegun300lvl5 : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectWeaponWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemMachinegun300lvl4>(count: 1);
            inputItems.Add<ItemComponentsWeapon>(count: 5);
            inputItems.Add<ItemIngotSteel>(count: 5);
            inputItems.Add<ItemPlastic>(count: 2);
            inputItems.Add<ItemManualMachinegun300Lvl5>(count: 1);

            outputItems.Add<ItemMachinegun300lvl5>();
        }

        protected override void PrepareOrigin()
        {
            dependOrigins = new List<String>();
            dependOrigins.Add("Trader");
        }
    }
}