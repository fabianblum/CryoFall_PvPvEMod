namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Melee;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairItemStunBaton : Recipe.RecipeForStationCrafting
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

            inputItems.Add<ItemWire>(count: 10);
            inputItems.Add<ItemPowerCell>(count: 2);
            inputItems.Add<ItemComponentsElectronic>(count: 10);
			inputItems.Add<ItemPlastic>(count: 3);
			inputItems.Add<ItemDuctTape>(count: 1);
			inputItems.Add<ItemStunBaton>(count: 1);

            outputItems.Add<ItemStunBaton>();
        }
    }
}