namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    using AtomicTorch.CBND.CoreMod.SoundPresets;

    public class ItemMetalArmorlvl2 : ItemMetalArmor
    {
        public override uint DurabilityMax => 1050;

        public override string Name => "Metal armor LVL 2";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.62,
                kinetic: 0.47,
                explosion: 0.42,
                heat: 0.22,
                cold: 0.12,
                chemical: 0.17,
                radiation: 0.12,
                psi: 0.0);

            // normal value override, we don't want it to be affected by armor multiplier later
            defense.Psi = 0.17 / defense.Multiplier;
        }
    }
}