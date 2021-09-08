namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;

    public class ItemSubmachinegun10mmlvl3 : ItemSubmachinegun10mmlvl2
    {
        public override double AmmoReloadDuration => 1.5;

        public override string Description => base.Description + ", Reload duration";

        public override string Name => "Submachine gun LVL 3";
    }
}