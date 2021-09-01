namespace AtomicTorch.CBND.CoreMod.Items.Food
{
    using System;
    using AtomicTorch.CBND.CoreMod.SoundPresets;

    public class ItemBeans : ProtoItemFood
    {
        public override string Description => "These tasty beans are suitable for eating raw and preserve well in cans.";

        public override float FoodRestore => 7;

        public override TimeSpan FreshnessDuration => ExpirationDuration.Normal;

        public override string Name => "Beans";

        public override ushort OrganicValue => 5;

        protected override ReadOnlySoundPreset<ItemSound> PrepareSoundPresetItem()
        {
            return ItemsSoundPresets.ItemFoodFruit;
        }
    }
}