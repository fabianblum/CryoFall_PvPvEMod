namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;

    public class ItemSubmachinegun10mmlvl4 : ItemSubmachinegun10mmlvl3
    {
        public override double DamageMultiplier => 0.9; // slightly lower than default

        public override uint DurabilityMax => 800;

        public override string Description => base.Description + ", Damage, Durability";

        public override string Name => "Submachine gun LVL 4";
    }
}