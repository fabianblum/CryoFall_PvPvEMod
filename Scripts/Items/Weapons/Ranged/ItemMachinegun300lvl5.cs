namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;

    public class ItemMachinegun300lvl5 : ItemMachinegun300lvl4
    {
        public override double FireInterval => 1 / 10d;

        public override string Description => base.Description + ", shots per seconds";

        public override string Name => "Custom Heavy machine gun LVL 5";
    }
}