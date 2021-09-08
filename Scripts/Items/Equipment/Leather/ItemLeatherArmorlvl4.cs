namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    using AtomicTorch.CBND.CoreMod.SoundPresets;

    public class ItemLeatherArmorlvl4 : ItemLeatherArmorlvl3
    {
        public override uint DurabilityMax => 950;

        public override ObjectMaterial Material => ObjectMaterial.SoftTissues;

        public override string Name => "Leather armor LVL 4";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.56,
                kinetic: 0.46,
                explosion: 0.46,
                heat: 0.41,
                cold: 0.36,
                chemical: 0.26,
                radiation: 0.26,
                psi: 0.0);
        }
    }
}