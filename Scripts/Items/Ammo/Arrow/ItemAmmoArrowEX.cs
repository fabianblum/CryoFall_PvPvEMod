namespace AtomicTorch.CBND.CoreMod.Items.Ammo
{
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects;
    using AtomicTorch.CBND.CoreMod.CharacterStatusEffects.Debuffs;
    using AtomicTorch.CBND.CoreMod.Items.Weapons;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Deposits;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Explosives;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Minerals;
    using AtomicTorch.CBND.CoreMod.Systems.Weapons;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Weapons;
    using AtomicTorch.CBND.GameApi.Data.World;

    public class ItemAmmoArrowEX : ProtoItemGrenade, IAmmoArrowS
    {
        public override double DamageRadius => 2.9;

        public const double DamageToMinerals = 2000;

        public override string Description => "Explosive crossbow bolt.";

        public override double FireRangeMax => 7;

        public override bool IsReferenceAmmo => false;


        public override ushort MaxItemsPerStack => ItemStackSize.Small;

        public override string Name => "Explosive crossbow bolt";

        public override double ServerCalculateTotalDamageByExplosive(
            ICharacter byCharacter,
            IStaticWorldObject targetStaticWorldObject)
        {
            var targetStaticWorldObjectProto = targetStaticWorldObject.ProtoStaticWorldObject;
            if (targetStaticWorldObjectProto is IProtoObjectMineral
                || targetStaticWorldObjectProto is IProtoObjectDeposit)
            {
                // the target object is a mineral or deposit, deal special damage
                return DamageToMinerals;
            }

            return base.ServerCalculateTotalDamageByExplosive(byCharacter, targetStaticWorldObject);
        }
        protected override void PrepareDamageDescriptionCharacters(
            out double damageValue,
            out double armorPiercingCoef,
            out double finalDamageMultiplier,
            DamageDistribution damageDistribution)
        {
            damageValue = 25;
            armorPiercingCoef = 0;
            finalDamageMultiplier = 1;

            damageDistribution.Set(DamageType.Explosion, 1.0);
        }

        protected override void PrepareDamageDescriptionStructures(
            out double damageValue,
            out double defencePenetrationCoef)
        {
            damageValue = 25;
            defencePenetrationCoef = 0;
        }

        protected override void PrepareExplosionPreset(out ExplosionPreset explosionPreset)
        {
            explosionPreset = ExplosionPresets.Large;
        }

        protected override WeaponFireTracePreset PrepareFireTracePreset()
        {
            return WeaponFireTracePresets.ArrowEX;
        }

        protected override void ServerOnCharacterHitByExplosion(
            ICharacter damagedCharacter,
            double damage,
            WeaponFinalCache weaponCache)
        {
            if (damage < 1)
            {
                return;
            }
            // 25% chance to add bleeding
            damagedCharacter.ServerAddStatusEffect<StatusEffectBleeding>(intensity: 0.025);
        }
    }
}