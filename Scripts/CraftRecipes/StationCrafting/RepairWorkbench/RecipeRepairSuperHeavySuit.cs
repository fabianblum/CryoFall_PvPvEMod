namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using AtomicTorch.CBND.CoreMod.Items.Equipment.SuperHeavyArmor;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;
    using System;

    public class RecipeRepairSuperHeavySuit : Recipe.RecipeForStationCrafting
    {
        public override bool IsAutoUnlocked => false;

        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.VeryLong;

            inputItems.Add<ItemIngotSteel>(count: 50);
            inputItems.Add<ItemAramidFiber>(count: 10);
            inputItems.Add<ItemKeinite>(count: 10);
            inputItems.Add<ItemComponentsHighTech>(count: 5);
            inputItems.Add<ItemBallisticPlate>(count: 5);
			inputItems.Add<ItemGlue>(count: 3);			
			inputItems.Add<ItemSuperHeavySuitlvl2>();			

            outputItems.Add<ItemSuperHeavySuitlvl2>();
        }
    }
}