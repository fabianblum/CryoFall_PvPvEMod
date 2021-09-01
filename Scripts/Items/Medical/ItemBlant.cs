namespace AtomicTorch.CBND.CoreMod.Items.Medical
{
    using AtomicTorch.CBND.CoreMod.Characters;
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects;
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects.Debuffs;
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects.Neutral;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.GameApi.Data.Characters;

    public class ItemBlant : ProtoItemMedical
    {
        public override double CooldownDuration => MedicineCooldownDuration.Short;

        public override string Description =>
            "Stimulant, side effects may vary.";

        public override double MedicalToxicity => 0.1;

        public override string Name => "Joint";

        public override float StaminaRestore => 200;

        protected override void ServerOnUse(ICharacter character, PlayerCharacterCurrentStats currentStats)
        {
            character.ServerAddStatusEffect<StatusEffectGanja>(intensity: 0.4); // 3 minutes

            base.ServerOnUse(character, currentStats);
        }
       

        protected override ReadOnlySoundPreset<ItemSound> PrepareSoundPresetItem()
        {
            return ItemsSoundPresets.ItemMedicalTablets;
        }
    }
}