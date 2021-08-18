namespace AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects;
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects.Debuffs;
    using AtomicTorch.CBND.CoreMod.Items.Ammo;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.CoreMod.Systems.Weapons;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Weapons;
    using AtomicTorch.CBND.GameApi.Data.World;
    using AtomicTorch.CBND.GameApi.Resources;
    using AtomicTorch.CBND.GameApi.ServicesClient.Rendering;
    using AtomicTorch.GameEngine.Common.Helpers;
    using AtomicTorch.GameEngine.Common.Primitives;

    public class ItemLaserCarbine : ProtoItemWeaponRangedEnergy
    {
        private static readonly TextureResource TextureResourceBeam
            = new("FX/WeaponTraces/TraceBeamLaser.png");

        public override double CharacterAnimationAimingRecoilDuration => 0.1;

        public override double CharacterAnimationAimingRecoilPower => 0.15;

        public override string Description =>
            "Laser carbine from Vanguard Technologies. Its pragmium core allows the fastest rate of fire but makes it hard to stabilize its recoil. Anyways, its accuracy improves notably when shooting short bursts.";

        public override uint DurabilityMax => 800;

        public override double EnergyUsePerShot => 50;

        public override double FireInterval => 0.12;

        public override string Name => "Laser carbine";

        public override float ShotVolumeMultiplier => 1.25f;

        public override double SpecialEffectProbability => 0.4;
		
		public override double FirePatternCooldownDuration => this.FireInterval + 0.06;

        protected override WeaponFireScatterPreset PrepareFireScatterPreset()
        {
            return new(
                new[] { -0.25, 0.25 });
        }

        protected override WeaponFirePatternPreset PrepareFirePatternPreset()
        {
            return new(
                initialSequence: new[] { 0.0, 0.5},
                cycledSequence: new[] { 5.0, -8.0, 10, -12, 16, -18 });
        }

        public override void ClientOnWeaponHitOrTrace(
            ICharacter firingCharacter,
            Vector2D worldPositionSource,
            IProtoItemWeapon protoWeapon,
            IProtoItemAmmo protoAmmo,
            IProtoCharacter protoCharacter,
            in Vector2Ushort fallbackCharacterPosition,
            IReadOnlyList<WeaponHitData> hitObjects,
            in Vector2D endPosition,
            bool endsWithHit)
        {
            ComponentWeaponEnergyBeam.Create(
                sourcePosition: worldPositionSource,
                targetPosition: endPosition,
                traceStartWorldOffset: 0.25,
                texture: TextureResourceBeam,
                beamWidth: 0.005,
                originOffset: Vector2D.Zero,
                duration: 0.1,
                endsWithHit,
                fadeInDistance: 0.2,
                fadeOutDistanceHit: 0,
                fadeOutDistanceNoHit: 0.8,
                blendMode: BlendMode.AlphaBlendPremultiplied);
        }

        public override void SharedOnHit(
            WeaponFinalCache weaponCache,
            IWorldObject damagedObject,
            double damage,
            WeaponHitData hitData,
            out bool isDamageStop)
        {
            base.SharedOnHit(weaponCache, damagedObject, damage, hitData, out isDamageStop);

            if (damage < 1)
            {
                return;
            }

            if (IsServer
                && damagedObject is ICharacter damagedCharacter
                && RandomHelper.RollWithProbability(0.4))
            {
                damagedCharacter.ServerAddStatusEffect<StatusEffectDazed>(
                    // add 0.4 seconds of dazed effect
                    intensity: 0.2 / StatusEffectDazed.MaxDuration);
            }
        }

        protected override void ClientInitialize(ClientInitializeData data)
        {
            base.ClientInitialize(data);
            ComponentWeaponEnergyBeam.PreloadAssets();
            Client.Rendering.PreloadTextureAsync(TextureResourceBeam);
        }

        protected override WeaponFireTracePreset PrepareFireTracePreset()
        {
            // see ClientOnWeaponHitOrTrace for the custom laser ray implementation
            return WeaponFireTracePresets.LaserBlue;
        }

        protected override void PrepareMuzzleFlashDescription(MuzzleFlashDescription description)
        {
            description.Set(MuzzleFlashPresets.EnergyLaserWeaponBlue)
                       .Set(textureScreenOffset: (28, 9));
        }

        protected override void PrepareProtoWeaponRangedEnergy(
            ref DamageDescription damageDescription)
        {
            damageDescription = new DamageDescription(
                damageValue: 9,
                armorPiercingCoef: 0.5,
                finalDamageMultiplier: 1.5,
                rangeMax: 10,
                damageDistribution: new DamageDistribution(DamageType.Heat, 1));
        }

        protected override ReadOnlySoundPreset<WeaponSound> PrepareSoundPresetWeapon()
        {
            return WeaponsSoundPresets.WeaponRangedLaserRifle;
        }

        protected override void ServerOnSpecialEffect(ICharacter damagedCharacter, double damage)
        {
            ServerWeaponSpecialEffectsHelper.OnLaserHit(damagedCharacter, damage);
            // also, see SharedOnHit as it adds Dazed
        }
    }
}