namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    public class ItemLeatherHelmetPilotlvl4 : ItemLeatherHelmetPilot
    {
        public override uint DurabilityMax => 950;

        public override string Name => "Pilot hat LVL 4";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.56,
                kinetic: 0.46,
                explosion: 0.46,
                heat: 0.41,
                cold: 0.36,
                chemical: 0.26,
                radiation: 0.26,
                psi: 0.0);
        }
    }
}