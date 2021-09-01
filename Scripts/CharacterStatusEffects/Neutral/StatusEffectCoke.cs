namespace AtomicTorch.CBND.CoreMod.CharacterStatusEffects.Neutral
{
    using AtomicTorch.CBND.CoreMod.Stats;

    /// <summary>
    /// Note: it also works the same as painkiller but reduces pain by half (calculated inside the pain effect)
    /// 
    /// Also, don't do drugs in reality. It destroys your life. We condemn use of any drugs or other mind altering substances.
    /// </summary>
    public class StatusEffectCoke : ProtoStatusEffect
    {
        public override string Description
            => "You're high on cocaine";

        public override double IntensityAutoDecreasePerSecondValue
            => 1.0 / 900.0; // total of 10 minutes for max possible time

        public override StatusEffectKind Kind => StatusEffectKind.Neutral;

        public override string Name => "Influenced by Cocaine";

        protected override void PrepareEffects(Effects effects)
        {
      
            // Speeds +++
            effects.AddPercent(this, StatName.StaminaMax, 30);
            effects.AddPercent(this, StatName.StaminaRegenerationPerSecond, 20);
            effects.AddPercent(this, StatName.RunningStaminaConsumptionPerSecond, -20);

            effects.AddPercent(this, StatName.MoveSpeed, 15);
            effects.AddPercent(this, StatName.MoveSpeedRunMultiplier, 15);
            effects.AddPercent(this, StatName.MiningSpeed, 15);
            effects.AddPercent(this, StatName.WoodcuttingSpeed, 15);
            effects.AddPercent(this, StatName.ForagingSpeed, 15);
            effects.AddPercent(this, StatName.BuildingSpeed, 25);
            effects.AddPercent(this, StatName.FarmingTasksSpeed, 15);
            effects.AddPercent(this, StatName.HuntingLootingSpeed, 15);
            effects.AddPercent(this, StatName.SearchingSpeed, 15);
            effects.AddPercent(this, StatName.CraftingSpeed, 15);


        }
    }
}