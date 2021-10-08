namespace AtomicTorch.CBND.CoreMod.Characters.Mobs
{
    using AtomicTorch.CBND.CoreMod.CharacterOrigins;
    using AtomicTorch.CBND.CoreMod.CharacterSkeletons;
    using AtomicTorch.CBND.CoreMod.Items.Devices;
    using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Weapons.MobWeapons;
    using AtomicTorch.CBND.CoreMod.Skills;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.CoreMod.Stats;
    using AtomicTorch.CBND.CoreMod.Systems.Droplists;
    using AtomicTorch.CBND.CoreMod.Systems.ServerTimers;
    using AtomicTorch.CBND.GameApi.Data.World;
    using static Technologies.ServerTechTimeGateHelper;

    public class MobMutantCrawler : ProtoCharacterMob
    {
        public override bool AiIsRunAwayFromHeavyVehicles => false;

        public override float CharacterWorldHeight => 1.1f;

        public override float CharacterWorldWeaponOffsetRanged => 0.2f;

        public override double MobKillExperienceMultiplier => 0.7;

        public override string Name => "Mutant crawler";

        public override ObjectMaterial ObjectMaterial => ObjectMaterial.HardTissues;

        public override double StatDefaultHealthMax => 140;

        public override double StatMoveSpeed => 2.3;

        public override double StatMoveSpeedRunMultiplier => 1.3;

        protected override void FillDefaultEffects(Effects effects)
        {
            base.FillDefaultEffects(effects);

            effects.AddValue(this, StatName.DefenseImpact, 0.4)
                   .AddValue(this, StatName.DefenseKinetic, 0.9)
                   .AddValue(this, StatName.DefenseExplosion, 0.1)
                   .AddValue(this, StatName.DefenseHeat, 0.1)
                   .AddValue(this, StatName.DefenseChemical, 0.8)
                   .AddValue(this, StatName.DefenseCold, 0.9)
                   .AddValue(this, StatName.DefensePsi, 1.0)
                   .AddValue(this, StatName.DefenseRadiation, 1.0);
        }

        protected override void PrepareProtoCharacterMob(
            out ProtoCharacterSkeleton skeleton,
            ref double scale,
            DropItemsList lootDroplist)
        {
            DropItemConditionDelegate onlyBeforeT3SpecializedPvP = OnlyBeforeT3SpecializedAndPvP;
            DropItemConditionDelegate isTraderAndT3Specialized = CharacterOriginTrader.ConditionIsTraderOrigin;

            skeleton = GetProtoEntity<SkeletonMutantCrawler>();

            // primary loot
            lootDroplist
                .Add<ItemToxin>(count: 1)

                .Add<ItemGoldNugget>(count: 5, countRandom: 20, probability: .1)
                .Add<ItemOreIronConcentrate>(count: 5, countRandom: 20, probability: .1)
                .Add<ItemOreCopperConcentrate>(count: 5, countRandom: 20, probability: .1)
                .Add<ItemOreCopper>(count: 5, countRandom: 50, probability: .1)
                .Add<ItemOreIron>(count: 5, countRandom: 50, probability: .1)

                .Add(nestedList: new DropItemsList(outputs: 1)
                                 .Add<ItemInsectMeatRaw>(count: 1)
                                 .Add<ItemBones>(count: 1)
                                 .Add<ItemSlime>(count: 1)
                // requires device
                .Add<ItemKeiniteRaw>(count: 1, countRandom: 1, condition: ItemKeiniteCollector.ConditionHasDeviceEquipped));

            // extra loot
            lootDroplist.Add(condition: SkillHunting.ServerRollExtraLoot,
                             nestedList: new DropItemsList(outputs: 1)
                                         .Add<ItemInsectMeatRaw>(count: 1)
                                         .Add<ItemToxin>(count: 1)
                                         .Add<ItemBones>(count: 1)
                                         .Add<ItemSlime>(count: 2));

            // Manuals for all
            lootDroplist.Add(
                    weight: 1,
                    probability: .1,
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
                    probability: .35,
                    nestedList:
                    new DropItemsList(outputs: 1)
                        // resources / misc
                        .Add<ItemManualLeatherArmorLvl4>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualLeatherArmorLvl5>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualLeatherHelmetCowboyLvl4>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualLeatherHelmetCowboyLvl5>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualLeatherHelmetPilotLvl4>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualLeatherHelmetPilotLvl5>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualLeatherHelmetTricorneLvl4>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualLeatherHelmetTricorneLvl5>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualMachinegun300Lvl4>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualMachinegun300Lvl5>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualMachinePistolLvl4>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualMachinePistolLvl5>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualMetalArmorLvl4>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualMetalArmorLvl5>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualMetalHelmetClosedLvl4>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualMetalHelmetClosedLvl5>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualMetalHelmetSkullLvl4>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualMetalHelmetSkullLvl5>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualMilitaryArmorLvl4>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualMilitaryArmorLvl5>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualPragmiumSuitLvl4>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualPragmiumSuitLvl5>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualSubMachinegun10mmLvl4>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualSubMachinegun10mmLvl5>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualSuperHeavySuitLvl4>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                        .Add<ItemManualSuperHeavySuitLvl5>(count: 1, weight: 1, condition: isTraderAndT3Specialized)
                );
        }

        protected override void ServerInitializeCharacterMob(ServerInitializeData data)
        {
            base.ServerInitializeCharacterMob(data);

            var weaponProto = GetProtoEntity<ItemWeaponMobMutantCrawlerPoison>();
            data.PrivateState.WeaponState.SharedSetWeaponProtoOnly(weaponProto);
            data.PublicState.SharedSetCurrentWeaponProtoOnly(weaponProto);
        }

        protected override void ServerUpdateMob(ServerUpdateData data)
        {
            var character = data.GameObject;
            var currentStats = data.PublicState.CurrentStats;

            ServerCharacterAiHelper.ProcessAggressiveAi(
                character,
                targetCharacter: ServerCharacterAiHelper.GetClosestTargetPlayer(character),
                isRetreating: false,
                isRetreatingForHeavyVehicles: this.AiIsRunAwayFromHeavyVehicles,
                distanceRetreat: 0,
                distanceEnemyTooClose: 2,
                distanceEnemyTooFar: 8,
                movementDirection: out var movementDirection,
                rotationAngleRad: out var rotationAngleRad);

            this.ServerSetMobInput(character, movementDirection, rotationAngleRad);
        }
    }
}