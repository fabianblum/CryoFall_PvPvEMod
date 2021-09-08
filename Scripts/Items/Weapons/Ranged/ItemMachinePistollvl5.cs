namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;

    public class ItemMachinePistollvl5 : ItemMachinePistollvl4
    {
        public override string Description => base.Description + ", shots per seconds";

        public override double FireInterval => 1 / 12.0; // 10 per second

        public override string Name => "Machine pistol LVL 5";

    }
}