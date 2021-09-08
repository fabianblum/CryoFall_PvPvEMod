namespace AtomicTorch.CBND.CoreMod.Items.Equipment
{
    using AtomicTorch.CBND.CoreMod.SoundPresets;

    public class ItemMilitaryArmorlvl2 : ItemMilitaryArmor
    {
        public override uint DurabilityMax => 1050;

        public override string Name => "Military armor LVL 2";

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
        }
    }
}