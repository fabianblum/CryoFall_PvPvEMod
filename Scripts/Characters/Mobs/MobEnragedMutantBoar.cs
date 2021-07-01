﻿namespace AtomicTorch.CBND.CoreMod.Characters.Mobs
{
  using AtomicTorch.CBND.CoreMod.CharacterSkeletons;
  using AtomicTorch.CBND.CoreMod.Items.Devices;
  using AtomicTorch.CBND.CoreMod.Items.Food;
  using AtomicTorch.CBND.CoreMod.Items.Generic;
  using AtomicTorch.CBND.CoreMod.Items.Weapons.MobWeapons;
  using AtomicTorch.CBND.CoreMod.Skills;
  using AtomicTorch.CBND.CoreMod.Systems.Droplists;

  public class MobEnragedMutantBoar : MobEnragedWildBoar
  {
    public override double MobKillExperienceMultiplier => 5.0;

    public override string Name => "Enraged Mutated Boar";

    public override double StatDefaultHealthMax => 160;

    public override double StatMoveSpeed => 2.1;

    protected override void PrepareProtoCharacterMob(
        out ProtoCharacterSkeleton skeleton,
        ref double scale,
        DropItemsList lootDroplist)
    {
      skeleton = GetProtoEntity<SkeletonMutantBoar>();

      // primary loot
      lootDroplist
          .Add<ItemInsectMeatRaw>(count: 2, countRandom: 2)
          .Add<ItemLeather>(count: 1, countRandom: 1)
          .Add<ItemBones>(count: 1, countRandom: 1)
          // requires device
          .Add<ItemKeiniteRaw>(count: 1, probability:0.1, condition: ItemKeiniteCollector.ConditionHasDeviceEquipped);

      // extra loot
      //lootDroplist.Add(condition: SkillHunting.ServerRollExtraLoot,
      //                       nestedList: new DropItemsList(outputs: 1)
      //                                   .Add<ItemLeather>(count: 1)
      //                                   .Add<ItemBones>(count: 1));
    }

    protected override void ServerInitializeCharacterMob(ServerInitializeData data)
    {
      base.ServerInitializeCharacterMob(data);

      var weaponProto = GetProtoEntity<ItemWeaponMobEnragedGenericMedium>();
      data.PrivateState.WeaponState.SharedSetWeaponProtoOnly(weaponProto);
      data.PublicState.SharedSetCurrentWeaponProtoOnly(weaponProto);
    }

    protected override void ServerUpdateMob(ServerUpdateData data)
    {
      var character = data.GameObject;

      ServerEnragedAiHelper.ProcessAggressiveAi(
          character,
          targetStructure: ServerEnragedAiHelper.GetClosestTargetStructure(character),
          targetCharacter: ServerEnragedAiHelper.GetClosestTargetPlayer(character),
          distanceEnemyTooClose: 1,
          distanceEnemyTooFar: 25,
          movementDirection: out var movementDirection,
          rotationAngleRad: out var rotationAngleRad);

      this.ServerSetMobInput(character, movementDirection, rotationAngleRad);
    }
  }
}