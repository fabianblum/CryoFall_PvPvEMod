namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Ammo;
    using AtomicTorch.CBND.CoreMod.Skills;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Weapons;

    public class ItemCrossbowauto : ProtoItemBow2
    {
        public override ushort AmmoCapacity => 20;

        public override double AmmoReloadDuration => 8.00;

        public override string CharacterAnimationAimingName => "WeaponRifleAiming";

        public override double CharacterAnimationAimingRecoilDuration => 0.6;

        public override string CharacterAnimationAimingRecoilName => "WeaponRifleShooting";

        public override double CharacterAnimationAimingRecoilPower => 0.75;

        public override string Description => "Automatic Crossbow, good for hunting and self defense.";

        public override uint DurabilityMax => 750;

        public override double FireInterval => 1 / 5.0d; // 4.0 per second

        public override double DamageMultiplier => 1.4; // slightly higher

        public override string Name => "Auto Crossbow";
        public override (float min, float max) SoundPresetWeaponDistance
            => (SoundConstants.AudioListenerMinDistanceRangedShot,
                SoundConstants.AudioListenerMaxDistanceRangedShotBows);

        public override double SpecialEffectProbability => 0.25;

        public override double TimeToReadyAfterReloading => 0.25;

        protected override ProtoSkillWeapons WeaponSkill => null;

        protected override void PrepareMuzzleFlashDescription(MuzzleFlashDescription description)
        {
            description.Set(MuzzleFlashPresets.None);
        }

        protected override void PrepareProtoWeaponBow(
            out IEnumerable<IProtoItemAmmo> compatibleAmmoProtos,
            ref DamageDescription overrideDamageDescription)
        {
            compatibleAmmoProtos = GetAmmoOfType<IAmmoArrowS>();
        }

        protected override ReadOnlySoundPreset<WeaponSound> PrepareSoundPresetWeapon()
        {
            return WeaponsSoundPresets.WeaponRangedBow;
        }

        protected override void ServerOnSpecialEffect(ICharacter damagedCharacter, double damage)
        {
            ServerWeaponSpecialEffectsHelper.OnFirearmHit(damagedCharacter, damage);
        }
    }
}