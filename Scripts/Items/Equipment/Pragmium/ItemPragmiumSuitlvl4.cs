namespace AtomicTorch.CBND.CoreMod.Items.Equipment.PragmiumArmor
{
    using AtomicTorch.CBND.CoreMod.SoundPresets;

    public class ItemPragmiumSuitlvl4 : ItemPragmiumSuitlvl3
    {
        public override uint DurabilityMax => 1600;

        public override string Name => "Pragmium armor LVL 4";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.76,
                kinetic: 0.76,
                explosion: 0.76,
                heat: 0.76,
                cold: 0.76,
                chemical: 0.76,
                radiation: 0.56,
                psi: 0.56);
        }
    }
}