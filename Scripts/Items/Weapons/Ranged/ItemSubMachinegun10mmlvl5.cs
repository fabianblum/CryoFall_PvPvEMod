namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;

    public class ItemSubmachinegun10mmlvl5 : ItemSubmachinegun10mmlvl4
    {
        public override double FireInterval => 1 / 12.0;

        public override string Description => base.Description + ", shots per seconds";

        public override string Name => "Submachine gun LVL 5";
    }
}