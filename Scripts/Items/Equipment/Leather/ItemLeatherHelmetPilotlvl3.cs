namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    public class ItemLeatherHelmetPilotlvl3 : ItemLeatherHelmetPilot
    {
        public override uint DurabilityMax => 900;

        public override string Name => "Pilot hat LVL 3";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.54,
                kinetic: 0.44,
                explosion: 0.44,
                heat: 0.39,
                cold: 0.34,
                chemical: 0.24,
                radiation: 0.24,
                psi: 0.0);
        }
    }
}