namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    public class ItemMetalHelmetSkulllvl5 : ItemMetalHelmetSkulllvl3
    {
        public override uint DurabilityMax => 1200;

        public override string Name => "Metal skull helmet LVL 5";

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
            defense.Psi = 0.45 / defense.Multiplier;
        }
    }
}