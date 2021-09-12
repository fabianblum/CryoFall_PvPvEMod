namespace AtomicTorch.CBND.CoreMod.CharacterOrigins
{
    using AtomicTorch.CBND.CoreMod.Characters.Player;
    using AtomicTorch.CBND.CoreMod.Stats;
    using AtomicTorch.CBND.CoreMod.Systems.Droplists;

    public class CharacterOriginTrader : ProtoCharacterOrigin
    {
        public override string Description => "The merchant race is based on an extended family that specializes in trade. Through their years of experience with the trade, you can score with a lot of experience and tact. ith an eye for detail, they are able to find out manufacturing recipes more easily and make weapons and armor to a better degree. Since the merchant race specializes exclusively in trade, they refuse to raid bases completely.";

        public override string Name => "Trader";

        protected override void FillDefaultEffects(Effects effects)
        {
            effects
                .AddPercent(this, StatName.BuildingSpeed, 25)
                .AddPercent(this, StatName.FoodMax, 15)
                .AddValue(this, StatName.WaterMax, 15)
                .AddPercent(this, StatName.TraderTech, 100)
            .AddValue(this, StatName.PvEOnly, -1);
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

        public static bool ConditionIsNoTraderOrigin(DropItemContext context)
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

            return origin.ShortId != "Trader";
        }
    }
}