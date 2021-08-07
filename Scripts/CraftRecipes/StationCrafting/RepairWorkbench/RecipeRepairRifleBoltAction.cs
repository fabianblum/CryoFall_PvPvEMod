namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairRifleBoltAction : Recipe.RecipeForStationCrafting
    {
        public override bool IsAutoUnlocked => false;
		
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.Long;

            inputItems.Add<ItemIngotSteel>(count: 6);
            inputItems.Add<ItemIngotCopper>(count: 6);
            inputItems.Add<ItemLeather>(count: 2);
            inputItems.Add<ItemRubberVulcanized>(count: 1);
			inputItems.Add<ItemDuctTape>(count: 2);
			inputItems.Add<ItemRifleBoltAction>(count: 1);

            outputItems.Add<ItemRifleBoltAction>();
        }
    }
}