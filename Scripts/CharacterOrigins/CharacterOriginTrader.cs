namespace AtomicTorch.CBND.CoreMod.CharacterOrigins
{
    using AtomicTorch.CBND.CoreMod.Stats;

    public class CharacterOriginTrader : ProtoCharacterOrigin
    {
        public override string Description =>
            "The Traders are blaa.";

        public override string Name => "Trader";

        protected override void FillDefaultEffects(Effects effects)
        {
            effects
                .AddPercent(this, StatName.BuildingSpeed, 25)
                .AddPercent(this, StatName.FoodMax, 15)
                .AddValue(this, StatName.WaterMax, 15);
        }
    }
}