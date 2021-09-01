namespace AtomicTorch.CBND.CoreMod.CharacterStatusEffects.Neutral
{
    using AtomicTorch.CBND.CoreMod.Stats;

    /// <summary>
    /// Note: it also works the same as painkiller but reduces pain by half (calculated inside the pain effect)
    /// 
    /// Also, don't do drugs in reality. It destroys your life. We condemn use of any drugs or other mind altering substances.
    /// </summary>
    public class StatusEffectGanja : ProtoStatusEffect
    {
        public override string Description
            => "You're high on marihuana";

        public override double IntensityAutoDecreasePerSecondValue
            => 1.0 / 900.0; // total of 10 minutes for max possible time

        public override StatusEffectKind Kind => StatusEffectKind.Neutral;

        public override string Name => "Influenced by Marihuana";

        protected override void PrepareEffects(Effects effects)
        {
      
            // Speeds +++
            effects.AddPercent(this, StatName.StaminaMax, 40);
            effects.AddPercent(this, StatName.StaminaRegenerationPerSecond, 30);
            effects.AddPercent(this, StatName.RunningStaminaConsumptionPerSecond, -40);
			

			
			// learning
            effects.AddPercent(this, StatName.LearningsPointsGainMultiplier, 40)
                   .AddPercent(this, StatName.SkillsExperienceGainMultiplier, 40);
				   
				   
			// craft speed	   
			effects.AddPercent(this, StatName.CraftingSpeed, 500);


        }
    }
}