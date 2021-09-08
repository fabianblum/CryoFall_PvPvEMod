namespace AtomicTorch.CBND.CoreMod.Items.Equipment.PragmiumArmor
{
    using AtomicTorch.CBND.CoreMod.SoundPresets;

    public class ItemPragmiumSuitlvl2 : ItemPragmiumSuit
    {
        public override uint DurabilityMax => 1550;

        public override string Name => "Pragmium armor LVL 2";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.72,
                kinetic: 0.72,
                explosion: 0.72,
                heat: 0.72,
                cold: 0.72,
                chemical: 0.72,
                radiation: 0.52,
                psi: 0.52);
        }
    }
}