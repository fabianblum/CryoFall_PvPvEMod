namespace AtomicTorch.CBND.CoreMod.Items.Equipment.PragmiumArmor
{
    using AtomicTorch.CBND.CoreMod.SoundPresets;

    public class ItemPragmiumSuitlvl5 : ItemPragmiumSuitlvl4
    {
        public override uint DurabilityMax => 1700;

        public override string Name => "Pragmium armor LVL 5";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.80,
                kinetic: 0.80,
                explosion: 0.80,
                heat: 0.80,
                cold: 0.80,
                chemical: 0.80,
                radiation: 0.60,
                psi: 0.60);
        }
    }
}