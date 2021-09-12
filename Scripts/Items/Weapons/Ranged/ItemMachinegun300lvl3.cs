namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;

    public class ItemMachinegun300lvl3 : ItemMachinegun300lvl2
    {
        public override double AmmoReloadDuration => 2.0;

        public override string Description => base.Description + ", Reload duration";

        public override string Name => "Custom Heavy machine gun LVL 3";
    }
}