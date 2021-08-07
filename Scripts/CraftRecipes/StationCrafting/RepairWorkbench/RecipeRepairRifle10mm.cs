namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairRifle10mm : Recipe.RecipeForStationCrafting
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

            inputItems.Add<ItemIngotSteel>(count: 12);
            inputItems.Add<ItemPlastic>(count: 10);
            inputItems.Add<ItemComponentsWeapon>(count: 2);
			inputItems.Add<ItemDuctTape>(count: 2);
			inputItems.Add<ItemRifle10mm>(count: 1);

            outputItems.Add<ItemRifle10mm>();
        }
    }
}