namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    public class ItemMilitaryHelmetlvl5 : ItemMilitaryHelmet
    {
        public override uint DurabilityMax => 1250;

        public override string Name => "Military helmet LVL 5";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.6,
                kinetic: 0.7,
                explosion: 0.7,
                heat: 0.35,
                cold: 0.3,
                chemical: 0.4,
                radiation: 0.35,
                psi: 0.0);

            // normal value override, we don't want it to be affected by armor multiplier later
            defense.Psi = 0.4 / defense.Multiplier;
        }
    }
}