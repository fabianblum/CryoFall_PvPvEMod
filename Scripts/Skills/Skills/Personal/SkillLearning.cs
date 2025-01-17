﻿namespace AtomicTorch.CBND.CoreMod.Skills
{
    using AtomicTorch.CBND.CoreMod.Characters.Player;
    using AtomicTorch.CBND.CoreMod.Stats;
    using AtomicTorch.CBND.CoreMod.Systems.PvEZone;
    using AtomicTorch.CBND.CoreMod.Systems.Technologies;
    using AtomicTorch.CBND.CoreMod.Technologies;
    using AtomicTorch.CBND.GameApi.Data.Characters;

    public class SkillLearning : ProtoSkill
    {
        /// <summary>
        /// As you earn LP you also get EXP for this skill.
        /// </summary>
        public const double ExperienceAddedPerLPEarned = 20.0;

        public override string Description =>
            "Surviving in the unfamiliar environment of an alien world is difficult, but it offers unique opportunities to learn things you wouldn't know otherwise.";

        public override double ExperienceToLearningPointsConversionMultiplier =>
            0; // this skill doesn't give any LP as it is derivative skill of other skills EXP/LP gain

        public override string Name => "Learning";

        protected override void PrepareProtoSkill(SkillConfig config)
        {
            if (IsServer)
            {
                PlayerCharacterTechnologies.ServerCharacterGainedLearningPoints
                    += this.ServerCharacterGainedLearningPointsHandler;
            }

            config.Category = GetCategory<SkillCategoryPersonal>();

            var statName = StatName.LearningsPointsGainMultiplier;
            config.AddStatEffect(
                statName,
                formulaPercentBonus: level => level);

            config.AddStatEffect(
                statName,
                level: 10,
                percentBonus: 5);

            config.AddStatEffect(
                statName,
                level: 15,
                percentBonus: 5);

            config.AddStatEffect(
                statName,
                level: 20,
                percentBonus: 5);
        }

        private void ServerCharacterGainedLearningPointsHandler(
            ICharacter character,
            int gainedLearningPoints,
            bool ismodifiedbystat)
        {
            var xp = gainedLearningPoints * ExperienceAddedPerLPEarned;
            // compensate for the learning points gain speed (as it should not apply to the skill progression speed)
            xp /= PvEZoneMultiplier.getLearningPointsGainMultiplier(character);
            character.ServerAddSkillExperience(this, xp);
        }
    }
}