namespace AtomicTorch.CBND.CoreMod.Characters.Mobs
{
    using AtomicTorch.CBND.CoreMod.CharacterSkeletons;
    using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Medical;
    using AtomicTorch.CBND.CoreMod.Items.Equipment;
    using AtomicTorch.CBND.CoreMod.Items.Devices;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.MobWeapons;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.Ranged;
    using AtomicTorch.CBND.CoreMod.Items.Ammo;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.CoreMod.Objects;
    using AtomicTorch.CBND.CoreMod.Skills;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.CoreMod.Stats;
    using AtomicTorch.CBND.CoreMod.Systems.Droplists;
    using AtomicTorch.CBND.GameApi.Data.World;
    using AtomicTorch.CBND.CoreMod.CharacterOrigins;
    using static Technologies.ServerTechTimeGateHelper;

    public class MobNPC_BA_Specialist : ProtoCharacterRangedNPC
    {

        public override string Name => "Specialist";

        public override ObjectMaterial ObjectMaterial => ObjectMaterial.HardTissues;

        public override float CharacterWorldHeight => 1.5f;

        public override float CharacterWorldWeaponOffsetRanged => 0.4f;

        public override double StatMoveSpeed => 2.0;

        public override double StatMoveSpeedRunMultiplier => 1.1;

        public override bool AiIsRunAwayFromHeavyVehicles => false;

        public override double MobKillExperienceMultiplier => 1.0;

        public override double StatDefaultHealthMax => 220;

        public override double StatHealthRegenerationPerSecond => 20.0 / 20.0; // Default: 10/60 10 health points per minute

        public override bool IsAvailableInCompletionist => false;

        public override double RetreatDistance => 5;

        public override double EnemyToCloseDistance => 9;

        public override double EnemyToFarDistance => 14;

        public override bool RetreatWhenReloading => true;

        public override double RetreatingHealthPercentage => 60.0;

        protected override void FillDefaultEffects(Effects effects)
        {
            base.FillDefaultEffects(effects);

            effects.AddValue(this, StatName.DefenseImpact, 0.5);
            effects.AddValue(this, StatName.DefenseKinetic, 0.65);
            effects.AddValue(this, StatName.DefenseExplosion, 0.4);
            effects.AddValue(this, StatName.DefenseChemical, 0.3);

        }

        protected override void PrepareProtoCharacterMob(
               out ProtoCharacterSkeleton skeleton,
               ref double scale,
               DropItemsList lootDroplist)
        {
            DropItemConditionDelegate onlyBeforeT3SpecializedPvP = OnlyBeforeT3SpecializedAndPvP;
            DropItemConditionDelegate isTraderAndT3Specialized = CharacterOriginTrader.ConditionIsTraderOrigin;
            DropItemConditionDelegate isNoTrader = CharacterOriginTrader.ConditionIsNoTraderOrigin;
            DropItemConditionDelegate T3Specialized = IsAvailableT3Specialized;

            skeleton = GetProtoEntity<CharacterSkeletons.NPC_BA_Specialist>();

            // primary loot
            lootDroplist.Add(
              new DropItemsList(outputs: 1, outputsRandom: 1)

                .Add<ItemAmmo10mmArmorPiercing>(count: 20, countRandom: 30, weight: 12)
                .Add<ItemBandage>(count: 1, countRandom: 1, weight: 7)
                .Add<ItemCigarettes>(count: 1, countRandom: 1, weight: 6)
                .Add<ItemMRE>(count: 1, weight: 2)
                .Add<ItemMedkit>(count: 1, weight: 1));

            // extra loot from skill
            lootDroplist.Add(
                condition: SkillSearching.ServerRollExtraLoot,
                nestedList:
                new DropItemsList(outputs: 1)

          .Add<ItemMilitaryArmor>(count: 1, weight: 1, condition: T3Specialized)
          .Add<ItemSubmachinegun10mm>(count: 1, weight: 1, condition: T3Specialized));

            // Manuals for all
            lootDroplist.Add(
                    weight: 1,
                    probability: .5,
                    condition: isNoTrader,
                    nestedList:
                    new DropItemsList(outputs: 1)
                        // resources / misc
                        .Add<ItemManualLeatherArmorLvl2>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherArmorLvl3>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherHelmetCowboyLvl2>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherHelmetCowboyLvl3>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherHelmetPilotLvl2>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherHelmetPilotLvl3>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherHelmetTricorneLvl2>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherHelmetTricorneLvl3>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualMachinegun300Lvl2>(count: 1, weight: 1)
                        .Add<ItemManualMachinegun300Lvl3>(count: 1, weight: 1)
                        .Add<ItemManualMachinePistolLvl2>(count: 1, weight: 1)
                        .Add<ItemManualMachinePistolLvl3>(count: 1, weight: 1)
                        .Add<ItemManualMetalArmorLvl2>(count: 1, weight: 1)
                        .Add<ItemManualMetalArmorLvl3>(count: 1, weight: 1)
                        .Add<ItemManualMetalHelmetClosedLvl2>(count: 1, weight: 1)
                        .Add<ItemManualMetalHelmetClosedLvl3>(count: 1, weight: 1)
                        .Add<ItemManualMetalHelmetSkullLvl2>(count: 1, weight: 1)
                        .Add<ItemManualMetalHelmetSkullLvl3>(count: 1, weight: 1)
                        .Add<ItemManualMilitaryArmorLvl2>(count: 1, weight: 1)
                        .Add<ItemManualMilitaryArmorLvl3>(count: 1, weight: 1)
                        .Add<ItemManualPragmiumSuitLvl2>(count: 1, weight: 1)
                        .Add<ItemManualPragmiumSuitLvl3>(count: 1, weight: 1)
                        .Add<ItemManualSubMachinegun10mmLvl2>(count: 1, weight: 1)
                        .Add<ItemManualSubMachinegun10mmLvl3>(count: 1, weight: 1)
                        .Add<ItemManualSuperHeavySuitLvl2>(count: 1, weight: 1)
                        .Add<ItemManualSuperHeavySuitLvl3>(count: 1, weight: 1)
                );
            lootDroplist.Add(
                    weight: 1,
                    probability: .75,
                    condition: isTraderAndT3Specialized,
                    nestedList:
                    new DropItemsList(outputs: 1)
                        // resources / misc
                        .Add<ItemManualLeatherArmorLvl2>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherArmorLvl3>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherHelmetCowboyLvl2>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherHelmetCowboyLvl3>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherHelmetPilotLvl2>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherHelmetPilotLvl3>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherHelmetTricorneLvl2>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualLeatherHelmetTricorneLvl3>(count: 1, weight: 1, condition: onlyBeforeT3SpecializedPvP)
                        .Add<ItemManualMachinegun300Lvl2>(count: 1, weight: 1)
                        .Add<ItemManualMachinegun300Lvl3>(count: 1, weight: 1)
                        .Add<ItemManualMachinePistolLvl2>(count: 1, weight: 1)
                        .Add<ItemManualMachinePistolLvl3>(count: 1, weight: 1)
                        .Add<ItemManualMetalArmorLvl2>(count: 1, weight: 1)
                        .Add<ItemManualMetalArmorLvl3>(count: 1, weight: 1)
                        .Add<ItemManualMetalHelmetClosedLvl2>(count: 1, weight: 1)
                        .Add<ItemManualMetalHelmetClosedLvl3>(count: 1, weight: 1)
                        .Add<ItemManualMetalHelmetSkullLvl2>(count: 1, weight: 1)
                        .Add<ItemManualMetalHelmetSkullLvl3>(count: 1, weight: 1)
                        .Add<ItemManualMilitaryArmorLvl2>(count: 1, weight: 1)
                        .Add<ItemManualMilitaryArmorLvl3>(count: 1, weight: 1)
                        .Add<ItemManualPragmiumSuitLvl2>(count: 1, weight: 1)
                        .Add<ItemManualPragmiumSuitLvl3>(count: 1, weight: 1)
                        .Add<ItemManualSubMachinegun10mmLvl2>(count: 1, weight: 1)
                        .Add<ItemManualSubMachinegun10mmLvl3>(count: 1, weight: 1)
                        .Add<ItemManualSuperHeavySuitLvl2>(count: 1, weight: 1)
                        .Add<ItemManualSuperHeavySuitLvl3>(count: 1, weight: 1)
                );

            // Manuals for Traders
            lootDroplist.Add(
                    weight: 1,
                    probability: .75,
                    condition: isTraderAndT3Specialized,
                    nestedList:
                    new DropItemsList(outputs: 1)
                        // resources / misc
                        .Add<ItemManualLeatherArmorLvl4>(count: 1, weight: 1)
                        .Add<ItemManualLeatherArmorLvl5>(count: 1, weight: 1)
                        .Add<ItemManualLeatherHelmetCowboyLvl4>(count: 1, weight: 1)
                        .Add<ItemManualLeatherHelmetCowboyLvl5>(count: 1, weight: 1)
                        .Add<ItemManualLeatherHelmetPilotLvl4>(count: 1, weight: 1)
                        .Add<ItemManualLeatherHelmetPilotLvl5>(count: 1, weight: 1)
                        .Add<ItemManualLeatherHelmetTricorneLvl4>(count: 1, weight: 1)
                        .Add<ItemManualLeatherHelmetTricorneLvl5>(count: 1, weight: 1)
                        .Add<ItemManualMachinegun300Lvl4>(count: 1, weight: 1)
                        .Add<ItemManualMachinegun300Lvl5>(count: 1, weight: 1)
                        .Add<ItemManualMachinePistolLvl4>(count: 1, weight: 1)
                        .Add<ItemManualMachinePistolLvl5>(count: 1, weight: 1)
                        .Add<ItemManualMetalArmorLvl4>(count: 1, weight: 1)
                        .Add<ItemManualMetalArmorLvl5>(count: 1, weight: 1)
                        .Add<ItemManualMetalHelmetClosedLvl4>(count: 1, weight: 1)
                        .Add<ItemManualMetalHelmetClosedLvl5>(count: 1, weight: 1)
                        .Add<ItemManualMetalHelmetSkullLvl4>(count: 1, weight: 1)
                        .Add<ItemManualMetalHelmetSkullLvl5>(count: 1, weight: 1)
                        .Add<ItemManualMilitaryArmorLvl4>(count: 1, weight: 1)
                        .Add<ItemManualMilitaryArmorLvl5>(count: 1, weight: 1)
                        .Add<ItemManualPragmiumSuitLvl4>(count: 1, weight: 1)
                        .Add<ItemManualPragmiumSuitLvl5>(count: 1, weight: 1)
                        .Add<ItemManualSubMachinegun10mmLvl4>(count: 1, weight: 1)
                        .Add<ItemManualSubMachinegun10mmLvl5>(count: 1, weight: 1)
                        .Add<ItemManualSuperHeavySuitLvl4>(count: 1, weight: 1)
                        .Add<ItemManualSuperHeavySuitLvl5>(count: 1, weight: 1)
                );
        }

        protected override void ServerInitializeCharacterMob(ServerInitializeData data)
        {
            base.ServerInitializeCharacterMob(data);

            var weaponProto = GetProtoEntity<ItemWeaponMobSMG>();
            data.PrivateState.WeaponState.SharedSetWeaponProtoOnly(weaponProto);
            data.PublicState.SharedSetCurrentWeaponProtoOnly(weaponProto);

        }

        protected override void ServerOnAggro(ICharacter characterMob, ICharacter characterToAggro)
        {
            // cannot auto-aggro
        }

    }
}