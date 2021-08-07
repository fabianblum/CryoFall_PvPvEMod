namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Devices;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairPowerBankLarge : Recipe.RecipeForStationCrafting
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

            inputItems.Add<ItemIngotCopper>(count: 20);
            inputItems.Add<ItemPowerCell>(count: 2);
            inputItems.Add<ItemComponentsElectronic>(count: 5);
			inputItems.Add<ItemGlue>(count: 1);
			inputItems.Add<ItemPowerBankLarge>(count: 1);

            outputItems.Add<ItemPowerBankLarge>();
        }
    }
}