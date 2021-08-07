namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Devices;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Tools.Special;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairPragmiumSensor : Recipe.RecipeForStationCrafting
    {
        public override bool IsAutoUnlocked => false;

        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.Medium;

            inputItems.Add<ItemPlastic>(count: 5);
            inputItems.Add<ItemComponentsElectronic>(count: 3);
            inputItems.Add<ItemOrePragmium>(count: 1);
            inputItems.Add<ItemPowerCell>(count: 1);
			inputItems.Add<ItemDuctTape>(count: 2);
			inputItems.Add<ItemPragmiumSensor>();

            outputItems.Add<ItemPragmiumSensor>();
        }
    }
}