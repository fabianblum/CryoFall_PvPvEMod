namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    using AtomicTorch.CBND.CoreMod.SoundPresets;

    public class ItemMilitaryArmorlvl5 : ItemMilitaryArmor
    {
        public override uint DurabilityMax => 1250;

        public override string Name => "Military armor LVL 5";

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
        }
    }
}