namespace AtomicTorch.CBND.CoreMod.Items.Ammo
{
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects;
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects.Debuffs;
    using AtomicTorch.CBND.CoreMod.Items.Weapons;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Weapons;
    using AtomicTorch.GameEngine.Common.Helpers;

    public class ItemAmmoArrowSteel : ProtoItemAmmo, IAmmoArrowS
    {
        public override string Description => "Well balanced, steel tipped crossbow bolt.";

        public override bool IsReferenceAmmo => true;

        public override string Name => "Steel crossbow bolt";
        //public override void ServerOnCharacterHit(ICharacter damagedCharacter, double damage)
        //{
            // 10% chance to add bleeding
        //    if (RandomHelper.RollWithProbability(0.10))
        //    {
        //        damagedCharacter.ServerAddStatusEffect<StatusEffectBleeding>(intensity: 0.10); // 60 seconds
        //    }

            // Change this to whatever effect the gun needs
            //damagedCharacter.ServerAddStatusEffect<StatusEffectHeat>(intensity: 0.4);
        //}

        protected override void PrepareDamageDescription(
            out double damageValue,
            out double armorPiercingCoef,
            out double finalDamageMultiplier,
            out double rangeMax,
            DamageDistribution damageDistribution)
        {
            damageValue = 17;
            armorPiercingCoef = 0.5;
            finalDamageMultiplier = 1.2;
            rangeMax = 10;
            damageDistribution.Set(DamageType.Impact, 1);
        }

        protected override WeaponFireTracePreset PrepareFireTracePreset()
        {
            return WeaponFireTracePresets.Arrow;
        }
    }
}