namespace AtomicTorch.CBND.CoreMod.Rates
{
    using AtomicTorch.CBND.GameApi;

    public class RateSkillExperienceGainMultiplierPvE
        : BaseRateDouble<RateSkillExperienceGainMultiplierPvE>
    {
        [NotLocalizable]
        public override string Description => "Determines how quickly skills are leveled up (PvE).";

        public override string Id => "SkillExperienceGainMultiplierPvE";

        public override string Name => "Skill XP PvE";

        public override IRate OrderAfterRate
            => this.GetRate<RateLearningPointsGainMultiplierPvE>();

        public override double ValueDefault => 1.0;

        public override double ValueMax => 100.0;

        public override double ValueMaxReasonable => 5.0;

        public override double ValueMin => 0.1;

        public override double ValueMinReasonable => 1.0;

        public override RateValueType ValueType => RateValueType.Multiplier;

        public override RateVisibility Visibility => RateVisibility.Primary;
    }
}