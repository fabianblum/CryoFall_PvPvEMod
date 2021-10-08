namespace AtomicTorch.CBND.CoreMod.Rates
{
    using AtomicTorch.CBND.GameApi;

    public class RateLearningPointsGainMultiplierPvE
        : BaseRateDouble<RateLearningPointsGainMultiplierPvE>
    {
        [NotLocalizable]
        public override string Description => "Determines the learning points acquisition rate (PvE).";

        public override string Id => "LearningPointsGainMultiplierPvE";

        public override string Name => "Learning points PvE";

        public override double ValueDefault => 1.0;

        public override double ValueMax => 100.0;

        public override double ValueMaxReasonable => 5.0;

        public override double ValueMin => 0.1;

        public override double ValueMinReasonable => 1.0;

        public override RateValueType ValueType => RateValueType.Multiplier;

        public override RateVisibility Visibility => RateVisibility.Primary;
    }
}