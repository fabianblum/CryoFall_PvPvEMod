namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;

    public class ItemMachinegun300lvl2 : ItemMachinegun300
    {
        public override ushort AmmoCapacity => 24;

        public override string Description => base.Description + "Improved: Magazine";

        public override string Name => "Custom Heavy machine gun LVL 2";
    }
}