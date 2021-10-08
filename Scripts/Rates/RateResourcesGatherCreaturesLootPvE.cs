namespace AtomicTorch.CBND.CoreMod.Rates
{
    using AtomicTorch.CBND.GameApi;

    public class RateResourcesGatherCreaturesLootPvE
        : BaseRateDouble<RateResourcesGatherCreaturesLootPvE>
    {
        [NotLocalizable]
        public override string Description =>
            @"Determines the loot gathering rate from creatures.
              Increasing this number will provide more items when looting creature corpses PvE.";

        public override string Id => "Resources.Gather.CreaturesLootPvE";

        public override string Name => "[Resources] Gather—Creatures loot (PvE)";

        public override IRate OrderAfterRate
            => this.GetRate<RateResourcesGatherBasicPvE>();

        public override double ValueDefault => 1.0;

        public override double ValueMax => 100.0;

        public override double ValueMaxReasonable => 5.0;

        public override double ValueMin => 1.0;

        public override RateValueType ValueType => RateValueType.Multiplier;

        public override RateVisibility Visibility => RateVisibility.Primary;
    }
}