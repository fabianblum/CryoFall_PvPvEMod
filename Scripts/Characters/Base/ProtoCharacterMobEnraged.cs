﻿using AtomicTorch.CBND.CoreMod.Systems.Weapons;
using AtomicTorch.CBND.GameApi.Data.Characters;
using AtomicTorch.CBND.GameApi.Data.World;
using AtomicTorch.GameEngine.Common.Primitives;
using HardcoreDesert.Scripts.Characters.Base;

namespace AtomicTorch.CBND.CoreMod.Characters
{
  public abstract class ProtoCharacterMobEnraged
      <TPrivateState,
       TPublicState,
       TClientState>
      : ProtoCharacterMob
        <TPrivateState,
            TPublicState,
            TClientState>,
        IProtoCharacterMob,
        IProtoDamageToNPC
      where TPrivateState : CharacterMobEnragedPrivateState, new()
      where TPublicState : CharacterMobPublicState, new()
      where TClientState : BaseCharacterClientState, new()
  {
    public override bool AiIsRunAwayFromHeavyVehicles => false;

    //the npc is attacking himself with the test line
    public override Vector2D SharedGetWeaponFireWorldPosition(ICharacter character, bool isMeleeWeapon)
    {
      var characterRotationAngleRad = ((IProtoCharacterCore)character.ProtoCharacter)
        .SharedGetRotationAngleRad(character);

      return character.Position + (0, CharacterWorldWeaponOffsetMelee)
             + new Vector2D(0.5, 0)
                 .RotateRad(characterRotationAngleRad);

    }

    public override bool SharedOnDamage(WeaponFinalCache weaponCache, IWorldObject targetObject, double damagePreMultiplier, double damagePostMultiplier, out double obstacleBlockDamageCoef, out double damageApplied)
    {
      damageApplied = 0;
      obstacleBlockDamageCoef = 0;

      if (targetObject.ProtoGameObject is ProtoCharacterMobEnraged)
        return false;

      return base.SharedOnDamage(weaponCache, targetObject, damagePreMultiplier, damagePostMultiplier, out obstacleBlockDamageCoef, out damageApplied);
    }
  }

  public abstract class ProtoCharacterMobEnraged
      : ProtoCharacterMobEnraged
          <CharacterMobEnragedPrivateState,
              CharacterMobPublicState,
              CharacterMobClientState>
  {
  }
}