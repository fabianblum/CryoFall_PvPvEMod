namespace AtomicTorch.CBND.CoreMod.CharacterOrigins
{
    using AtomicTorch.CBND.CoreMod.Characters.Player;
    using AtomicTorch.CBND.CoreMod.Stats;
    using AtomicTorch.CBND.CoreMod.Systems.Droplists;

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

        public static bool ConditionIsTraderOrigin(DropItemContext context)
        {
            // Please note: checking this condition will also automatically deduct the device's durability.
            if (!context.HasCharacter)
            {
                return false;
            }

            // find the device
            var character = context.Character;
            var privateState = PlayerCharacter.GetPrivateState(character);
            var origin = privateState.Origin;

            return origin.ShortId == "Trader";
        }
    }
}