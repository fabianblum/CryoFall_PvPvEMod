namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    using AtomicTorch.CBND.CoreMod.SoundPresets;

    public class ItemMetalArmorlvl3 : ItemMetalArmor
    {
        public override uint DurabilityMax => 1100;

        public override string Name => "Metal armor LVL 3";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.64,
                kinetic: 0.49,
                explosion: 0.44,
                heat: 0.24,
                cold: 0.14,
                chemical: 0.19,
                radiation: 0.14,
                psi: 0.0);

            // normal value override, we don't want it to be affected by armor multiplier later
            defense.Psi = 0.19 / defense.Multiplier;
        }
    }
}