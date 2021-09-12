namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment.PragmiumArmor;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipePragmiumSuitlvl3 : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectArmorerWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemPragmiumSuitlvl2>(count: 1);
            inputItems.Add<ItemPragmiumSuit>(count: 1);
            inputItems.Add<ItemOrePragmium>(count: 30);
            inputItems.Add<ItemIngotSteel>(count: 7);
            inputItems.Add<ItemAramidFiber>(count: 7);
            inputItems.Add<ItemComponentsHighTech>(count: 3);
            inputItems.Add<ItemBallisticPlate>(count: 2);
            inputItems.Add<ItemManualPragmiumSuitLvl3>(count: 1);


            outputItems.Add<ItemPragmiumSuitlvl3>();
        }
    }
}