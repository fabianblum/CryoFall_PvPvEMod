namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    using AtomicTorch.CBND.CoreMod.SoundPresets;

    public class ItemLeatherArmorlvl2 : ItemLeatherArmor
    {
        public override uint DurabilityMax => 850;

        public override ObjectMaterial Material => ObjectMaterial.SoftTissues;

        public override string Name => "Leather armor LVL 2";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.52,
                kinetic: 0.42,
                explosion: 0.42,
                heat: 0.37,
                cold: 0.32,
                chemical: 0.22,
                radiation: 0.22,
                psi: 0.0);
        }
    }
}