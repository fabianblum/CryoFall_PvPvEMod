namespace AtomicTorch.CBND.CoreMod.Rates
{
    using AtomicTorch.CBND.GameApi;

    public class RateResourcesGatherCratesLootPvE
        : BaseRateDouble<RateResourcesGatherCratesLootPvE>
    {
        [NotLocalizable]
        public override string Description =>
            @"Determines the loot gathering rate from crates (such as loot crates in ruins/radtowns).
              Increasing this number will provide more items when searching crates and piles (PvE).";

        public override string Id => "Resources.Gather.CratesLootPvE";

        public override string Name => "[Resources] Gather—Crates and piles PvE";

        public override IRate OrderAfterRate
            => this.GetRate<RateResourcesGatherCreaturesLootPvE>();

        public override double ValueDefault => 1.0;

        public override double ValueMax => 100.0;

        public override double ValueMaxReasonable => 5.0;

        public override double ValueMin => 1.0;

        public override RateValueType ValueType => RateValueType.Multiplier;

        public override RateVisibility Visibility => RateVisibility.Primary;
    }
}