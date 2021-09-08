namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    using AtomicTorch.CBND.CoreMod.SoundPresets;

    public class ItemMetalArmorlvl5 : ItemMetalArmor
    {
        public override uint DurabilityMax => 1250;

        public override string Name => "Metal armor LVL 5";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.70,
                kinetic: 0.55,
                explosion: 0.50,
                heat: 0.30,
                cold: 0.20,
                chemical: 0.25,
                radiation: 0.20,
                psi: 0.0);

            // normal value override, we don't want it to be affected by armor multiplier later
            defense.Psi = 0.25 / defense.Multiplier;
        }
    }
}