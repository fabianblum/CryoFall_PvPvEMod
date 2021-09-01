namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Medical;
    using AtomicTorch.CBND.CoreMod.Items.Seeds;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeSeedsHerbHybrid : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectFarmingWorkbench>();

            duration = CraftingDuration.Short;

            inputItems.Add<ItemHerbGreen>(count: 10);
            inputItems.Add<ItemHerbRed>(count: 10);
            inputItems.Add<ItemHerbPurple>(count: 10);
            inputItems.Add<ItemSand>(count: 10);
            inputItems.Add<ItemFertilizer>(count: 5);

            outputItems.Add<ItemSeedsHerbHybrid>(count: 1);
        }
    }
}