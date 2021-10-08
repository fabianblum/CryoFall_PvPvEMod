namespace AtomicTorch.CBND.CoreMod.Rates
{
    using AtomicTorch.CBND.GameApi;

    public class RateResourcesGatherSpaceDebrisPvE
        : BaseRateDouble<RateResourcesGatherSpaceDebrisPvE>
    {
        [NotLocalizable]
        public override string Description =>
            @"Determines the resources gathering rate from space debris during the event.
              Increasing this number will provide more resources (PvE).";

        public override string Id => "Resources.Gather.SpaceDebrisPvE";

        public override string Name => "[Resources] Gather—Space debris PvE";

        public override IRate OrderAfterRate
            => this.GetRate<RateResourcesGatherCreaturesLootPvE>();

        public override double ValueDefault => 1.0;

        public override double ValueMax => 100.0;

        public override double ValueMaxReasonable => 5.0;

        public override double ValueMin => 1.0;

        public override RateValueType ValueType => RateValueType.Multiplier;

        public override RateVisibility Visibility => RateVisibility.Advanced;
    }
}