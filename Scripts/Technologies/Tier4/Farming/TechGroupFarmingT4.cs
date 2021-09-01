namespace AtomicTorch.CBND.CoreMod.Technologies.Tier4.Farming
{
    using AtomicTorch.CBND.CoreMod.Technologies.Tier3.Farming;

    public class TechGroupFarmingT4 : TechGroup
    {
        public override string Description => TechGroupsLocalization.FarmingDescription;

        public override string Name => TechGroupsLocalization.FarmingName;

        public override TechTier Tier => TechTier.Tier4;

        protected override void PrepareTechGroup(Requirements requirements)
        {
            requirements.AddGroup<TechGroupFarmingT3>(completion: 1);
        }
    }
}