namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    public class ItemMetalHelmetSkulllvl3 : ItemMetalHelmetSkulllvl2
    {
        public override uint DurabilityMax => 1050;

        public override string Name => "Metal skull helmet LVL 3";

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
            defense.Psi = 0.39 / defense.Multiplier;
        }
    }
}