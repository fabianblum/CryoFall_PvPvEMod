namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;

    public class ItemMachinePistollvl2 : ItemMachinePistol
    {
        public override ushort AmmoCapacity => 16;

        public override string Description => base.Description + " Improved: Magazine";

        public override string Name => "Machine pistol LVL 2";

    }
}