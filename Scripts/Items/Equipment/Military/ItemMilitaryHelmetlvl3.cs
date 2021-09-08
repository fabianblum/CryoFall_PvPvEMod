namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    public class ItemMilitaryHelmetlvl3 : ItemMilitaryHelmet
    {
        public override uint DurabilityMax => 1100;

        public override string Name => "Military helmet LVL 3";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.54,
                kinetic: 0.64,
                explosion: 0.64,
                heat: 0.29,
                cold: 0.24,
                chemical: 0.34,
                radiation: 0.29,
                psi: 0.0);

            // normal value override, we don't want it to be affected by armor multiplier later
            defense.Psi = 0.34 / defense.Multiplier;
        }
    }
}