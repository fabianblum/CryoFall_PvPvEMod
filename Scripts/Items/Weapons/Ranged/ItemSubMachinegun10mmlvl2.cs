namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;

    public class ItemSubmachinegun10mmlvl2 : ItemSubmachinegun10mm
    {
        public override ushort AmmoCapacity => 24;

        public override string Description => base.Description + "Improved: Magazine";

        public override string Name => "Submachine gun LVL 2";
    }
}