namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;

    public class ItemMachinegun300lvl4 : ItemMachinegun300lvl3
    {

        public override double DamageMultiplier => 0.95;

        public override string Description => base.Description + ", Damage, Durability";

        public override uint DurabilityMax => 900;

        public override string Name => "Custom Heavy machine gun LVL 4";
    }
}