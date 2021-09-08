namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    public class ItemMilitaryHelmetlvl2 : ItemMilitaryHelmet
    {
        public override uint DurabilityMax => 1050;

        public override string Name => "Military helmet LVL 2";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.52,
                kinetic: 0.62,
                explosion: 0.62,
                heat: 0.27,
                cold: 0.22,
                chemical: 0.32,
                radiation: 0.27,
                psi: 0.0);

            // normal value override, we don't want it to be affected by armor multiplier later
            defense.Psi = 0.32 / defense.Multiplier;
        }
    }
}