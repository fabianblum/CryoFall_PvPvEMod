namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;

    public class ItemMachinegun300lvl5 : ItemMachinegun300lvl4
    {
        public override double FireInterval => 1 / 10d;

        public override string Description => "Improved Heavy machine gun developed for high-power .300 rounds. With a custom mag.";

        public override string Name => "Custom Heavy machine gun LVL 5";
    }
}