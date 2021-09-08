namespace AtomicTorch.CBND.CoreMod.Items.Equipment.PragmiumArmor
{
    using AtomicTorch.CBND.CoreMod.SoundPresets;

    public class ItemPragmiumSuitlvl3 : ItemPragmiumSuitlvl2
    {
        public override uint DurabilityMax => 1600;

        public override string Name => "Pragmium armor LVL 3";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.74,
                kinetic: 0.74,
                explosion: 0.74,
                heat: 0.74,
                cold: 0.74,
                chemical: 0.74,
                radiation: 0.54,
                psi: 0.54);
        }
    }
}