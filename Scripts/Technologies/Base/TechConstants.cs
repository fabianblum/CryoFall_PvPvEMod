namespace AtomicTorch.CBND.CoreMod.Technologies
{
    using System.Diagnostics.CodeAnalysis;
    using AtomicTorch.CBND.CoreMod.Rates;
    using AtomicTorch.CBND.GameApi.Scripting;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.CoreMod.Systems.PvEZone;

    [SuppressMessage("ReSharper", "RedundantExplicitArraySize")]
    public static class TechConstants
    {
        public const double LearningPointsPriceBase = 10;

        public const TechTier MaxTier = TechTier.Tier6;

        public const TechTier MinTier = TechTier.Tier1;

        public const TechTier PvPTimeGateStartsFromTier = TechTier.Tier3;

        /// <summary>
        /// This constant defines final value for LP gain multiplier at maximum skill level.
        /// This multiplier will fall linearly from 1 at level 0 to the maximum value specified here.
        /// Effectively it reduces LP gain as player raises a particular skill level.
        /// </summary>
        public const double SkillLearningPointMultiplierAtMaximumLevel = 0.33;

        public static readonly double ServerLearningPointsGainMultiplier;

        public static readonly double ServerSkillExperienceGainMultiplier;

        public static double GetServerSkillExperienceToLearningPointsConversionMultiplier(ICharacter character)
        {
            return 0.01 * PvEZoneMultiplier.getExperienceGainMultiplier(character);
        }

        public static readonly double[] TierGroupPriceMultiplier
            = new double[(byte)MaxTier]
            {
                // tier 1 (unlocked by default)
                0,
                // tier 2
                5.0,
                // tier 3
                10.0,
                // tier 4
                15.0,
                // tier 5
                20.0,
                // tier 6
                20.0
            };

        public static readonly double[] TierNodePriceMultiplier
            = new double[(byte)MaxTier]
            {
                // tier 1 (unlocked by default)
                1.0,
                // tier 2
                2.0,
                // tier 3
                3.0,
                // tier 4
                4.0,
                // tier 5
                5.0,
                // tier 6
                5.0
            };

        static TechConstants()
        {
            if (Api.IsClient)
            {
                return;
            }



            ServerLearningPointsGainMultiplier = RateLearningPointsGainMultiplier.SharedValue;
            ServerSkillExperienceGainMultiplier = RateSkillExperienceGainMultiplier.SharedValue;
        }

        public static double ClientLearningPointsGainMultiplier
            => RateLearningPointsGainMultiplier.SharedValue;

        public static PvPTechTimeGateDurations PvPTimeGates
            => RatePvPTimeGates.SharedGetTimeGateDurations();
    }
}