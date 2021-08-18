namespace AtomicTorch.CBND.CoreMod.Technologies.Tier5.VanguardWeapons
{
    using AtomicTorch.CBND.CoreMod.Technologies.Tier4.EnergyWeapons;
    using AtomicTorch.CBND.CoreMod.Technologies.Tier4.Offense;

    public class TechGroupVanguardWeaponsT5 : TechGroup
    {
        public override string Description => TechGroupsLocalization.VanguardWeaponsDescription;

        public override string Name => TechGroupsLocalization.VanguardWeaponsName;

        public override TechTier Tier => TechTier.Tier5;

        protected override void PrepareTechGroup(Requirements requirements)
        {
            requirements.AddGroup<TechGroupEnergyWeaponsT4>(completion: 1);
            requirements.AddGroup<TechGroupOffenseT4>(completion: 1);
        }
    }
}