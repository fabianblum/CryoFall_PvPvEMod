namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;

    public class ItemMachinePistollvl3 : ItemMachinePistollvl2
    {
        public override double AmmoReloadDuration => 2.0;

        public override string Description => base.Description + ", Reload duration";

        public override string Name => "Machine pistol LVL 3";

    }
}