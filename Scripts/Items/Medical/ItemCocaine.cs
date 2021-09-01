namespace AtomicTorch.CBND.CoreMod.Items.Medical
{
    using AtomicTorch.CBND.CoreMod.Characters;
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects;
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects.Debuffs;
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects.Neutral;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.GameApi.Data.Characters;

    public class ItemCocaine : ProtoItemMedical
    {
        public override double CooldownDuration => MedicineCooldownDuration.Short;

        public override string Description =>
            "A potent, powerful pain blocker and stimulant, side effects may vary.";

        public override double MedicalToxicity => 0.4;

        public override string Name => "Cocaine";

        public override float StaminaRestore => 200;

        protected override void ServerOnUse(ICharacter character, PlayerCharacterCurrentStats currentStats)
        {
            character.ServerAddStatusEffect<StatusEffectCoke>(intensity: 0.3); // 3 minutes

            base.ServerOnUse(character, currentStats);
        }
        protected override void PrepareEffects(EffectActionsList effects)
        {
            effects

                .WillRemoveEffect<StatusEffectPain>()                        // removes all pain
                .WillAddEffect<StatusEffectProtectionPain>(intensity: 0.75); // adds pain blocking
        }

        protected override ReadOnlySoundPreset<ItemSound> PrepareSoundPresetItem()
        {
            return ItemsSoundPresets.ItemMedicalTablets;
        }
    }
}