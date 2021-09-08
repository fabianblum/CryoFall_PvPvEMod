namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    using AtomicTorch.CBND.CoreMod.SoundPresets;

    public class ItemMetalArmorlvl4 : ItemMetalArmor
    {
        public override uint DurabilityMax => 1150;

        public override string Name => "Metal armor LVL 4";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.66,
                kinetic: 0.51,
                explosion: 0.46,
                heat: 0.26,
                cold: 0.16,
                chemical: 0.21,
                radiation: 0.16,
                psi: 0.0);

            // normal value override, we don't want it to be affected by armor multiplier later
            defense.Psi = 0.21 / defense.Multiplier;
        }
    }
}