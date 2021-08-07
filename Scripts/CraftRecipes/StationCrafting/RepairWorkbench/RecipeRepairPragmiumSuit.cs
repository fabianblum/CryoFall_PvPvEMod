namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment.PragmiumArmor;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairPragmiumSuit : Recipe.RecipeForStationCrafting
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

            inputItems.Add<ItemOrePragmium>(count: 50);
            inputItems.Add<ItemIngotSteel>(count: 10);
            inputItems.Add<ItemAramidFiber>(count: 10);
            inputItems.Add<ItemComponentsHighTech>(count: 5);
            inputItems.Add<ItemBallisticPlate>(count: 2);
            inputItems.Add<ItemGlue>(count: 3);
            inputItems.Add<ItemPragmiumSuit>();			
            
            outputItems.Add<ItemPragmiumSuit>();
        }
    }
}