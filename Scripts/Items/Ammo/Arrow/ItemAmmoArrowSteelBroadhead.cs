namespace AtomicTorch.CBND.CoreMod.Items.Ammo
{
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects;
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects.Debuffs;
    using AtomicTorch.CBND.CoreMod.Items.Weapons;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Weapons;
    using AtomicTorch.GameEngine.Common.Helpers;

    public class ItemAmmoArrowSteelBroadhead : ProtoItemAmmo, IAmmoArrowS
    {
        public override string Description =>
            "Well balanced, steel tipped crossbow bolt with broadhead tip, great for unarmoed targets";

        public override bool IsReferenceAmmo => false;

        public override string Name => "Steel broadhead crossbow bolt";
        public override void ServerOnCharacterHit(ICharacter damagedCharacter, double damage, ref bool isDamageStop)
        {
            if (damage < 1)
            {
                return;
            }

            damagedCharacter.ServerAddStatusEffect<StatusEffectBleeding>(intensity: 0.05); // 15 seconds
        }

        protected override void PrepareDamageDescription(
            out double damageValue,
            out double armorPiercingCoef,
            out double finalDamageMultiplier,
            out double rangeMax,
            DamageDistribution damageDistribution)
        {
            damageValue = 22;
            armorPiercingCoef = 0.0;
            finalDamageMultiplier = 1.2;
            rangeMax = 8;
            damageDistribution.Set(DamageType.Impact, 1);
        }

        protected override WeaponFireTracePreset PrepareFireTracePreset()
        {
            return WeaponFireTracePresets.ArrowBH;
        }
    }
}