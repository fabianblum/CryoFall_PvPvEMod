namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;

    public class ItemMachinePistollvl4 : ItemMachinePistollvl3
    {

        public override double DamageMultiplier => 0.9; // slightly lower than default

        public override string Description => base.Description + ", Damage, Durability";

        public override uint DurabilityMax => 600;

        public override string Name => "Machine pistol LVL 4";

    }
}