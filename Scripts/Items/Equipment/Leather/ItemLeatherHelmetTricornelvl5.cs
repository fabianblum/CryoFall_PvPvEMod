namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    public class ItemLeatherHelmetTricornelvl5 : ItemLeatherHelmetTricorne
    {

        public override uint DurabilityMax => 1050;

        public override string Name => "Pirate hat LVL 5";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.6,
                kinetic: 0.5,
                explosion: 0.5,
                heat: 0.45,
                cold: 0.4,
                chemical: 0.3,
                radiation: 0.3,
                psi: 0.0);
        }
    }
}