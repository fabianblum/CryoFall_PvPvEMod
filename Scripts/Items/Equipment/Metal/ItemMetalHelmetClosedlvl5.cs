namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    public class ItemMetalHelmetClosedlvl5 : ItemMetalHelmetClosed
    {
        public override uint DurabilityMax => 1250;

        public override string Name => "Closed metal helmet LVL 5";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.7,
                kinetic: 0.55,
                explosion: 0.5,
                heat: 0.3,
                cold: 0.2,
                chemical: 0.25,
                radiation: 0.2,
                psi: 0.0);

            // normal value override, we don't want it to be affected by armor multiplier later
            defense.Psi = 0.45 / defense.Multiplier;
        }
    }
}