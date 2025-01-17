﻿namespace AtomicTorch.CBND.CoreMod.Rates
{
    using AtomicTorch.CBND.GameApi;

    public class RateResourcesGatherMeteoritesPvE
        : BaseRateDouble<RateResourcesGatherMeteoritesPvE>
    {
        [NotLocalizable]
        public override string Description =>
            @"Determines the resources gathering rate from meteorites during the event.
              Increasing this number will provide more resources (PvE).";

        public override string Id => "Resources.Gather.MeteoritesPvE";

        public override string Name => "[Resources] Gather—Meteorites PvE";

        public override IRate OrderAfterRate
            => this.GetRate<RateResourcesGatherSpaceDebrisPvE>();

        public override double ValueDefault => 1.0;

        public override double ValueMax => 100.0;

        public override double ValueMaxReasonable => 5.0;

        public override double ValueMin => 1.0;

        public override RateValueType ValueType => RateValueType.Multiplier;

        public override RateVisibility Visibility => RateVisibility.Advanced;
    }
}