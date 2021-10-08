namespace AtomicTorch.CBND.CoreMod.Rates
{
    using AtomicTorch.CBND.GameApi;

    public class RateDepositsExtractionSpeedMultiplierPvE
        : BaseRateDouble<RateDepositsExtractionSpeedMultiplierPvE>
    {
        [NotLocalizable]
        public override string Description => "Deposits extraction rate for oil/Li extractors (PvE).";

        public override string Id => "Resources.DepositsExtractionSpeedMultiplierPvE";

        public override string Name => "[Resources] Deposits extraction speed PvE";

        public override IRate OrderAfterRate
            => this.GetRate<RateManufacturingSpeedMultiplierPvE>();

        public override double ValueDefault => 1.0;

        public override double ValueMax => 100.0;

        public override double ValueMaxReasonable => 5.0;

        public override double ValueMin => 0.1;

        public override double ValueMinReasonable => 1.0;

        public override RateValueType ValueType => RateValueType.Multiplier;

        public override RateVisibility Visibility => RateVisibility.Advanced;
    }
}