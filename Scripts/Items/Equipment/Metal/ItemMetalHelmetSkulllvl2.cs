namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    public class ItemMetalHelmetSkulllvl2 : ItemMetalHelmetSkull
    {
        public override uint DurabilityMax => 1000;

        public override string Name => "Metal skull helmet LVL 2";

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
            defense.Psi = 0.37 / defense.Multiplier;
        }
    }
}