namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    public class ItemMilitaryHelmetlvl4 : ItemMilitaryHelmet
    {
        public override uint DurabilityMax => 1150;

        public override string Name => "Military helmet LVL 4";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.56,
                kinetic: 0.66,
                explosion: 0.66,
                heat: 0.31,
                cold: 0.26,
                chemical: 0.36,
                radiation: 0.31,
                psi: 0.0);

            // normal value override, we don't want it to be affected by armor multiplier later
            defense.Psi = 0.36 / defense.Multiplier;
        }
    }
}