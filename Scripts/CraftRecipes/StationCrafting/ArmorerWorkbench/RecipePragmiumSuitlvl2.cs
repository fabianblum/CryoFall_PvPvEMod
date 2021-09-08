namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment.PragmiumArmor;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipePragmiumSuitlvl2 : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectArmorerWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemPragmiumSuit>(count: 1);
            
            
            outputItems.Add<ItemPragmiumSuitlvl2>();
        }
    }
}