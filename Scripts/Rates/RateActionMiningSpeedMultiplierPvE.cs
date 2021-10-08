namespace AtomicTorch.CBND.CoreMod.Rates
{
    using AtomicTorch.CBND.GameApi;

    public class RateActionMiningSpeedMultiplierPvE
        : BaseRateDouble<RateActionMiningSpeedMultiplierPvE>
    {
        [NotLocalizable]
        public override string Description =>
            "Adjusts the damage to minerals by tools and drones (PvE).";

        public override string Id => "Action.MiningSpeedMultiplierPvE";

        public override string Name => "Mining speed PvE";

        public override IRate OrderAfterRate
            => this.GetRate<RateCraftingSpeedMultiplierPvE>();

        public override double ValueDefault => 1.0;

        public override double ValueMax => 10.0;

        public override double ValueMaxReasonable => 5.0;

        public override double ValueMin => 1.0;

        public override RateValueType ValueType => RateValueType.Multiplier;

        public override RateVisibility Visibility => RateVisibility.Primary;
    }
}