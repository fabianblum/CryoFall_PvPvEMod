﻿namespace AtomicTorch.CBND.CoreMod.StaticObjects.Loot
{
  using AtomicTorch.CBND.CoreMod.Items.Generic;
  using AtomicTorch.CBND.CoreMod.Rates;
  using AtomicTorch.CBND.CoreMod.Skills;
  using AtomicTorch.CBND.CoreMod.SoundPresets;
  using AtomicTorch.CBND.CoreMod.Systems.Droplists;
  using AtomicTorch.CBND.CoreMod.Systems.Physics;
  using AtomicTorch.CBND.GameApi.Data.World;
  using AtomicTorch.CBND.GameApi.ServicesClient.Components;
  using AtomicTorch.GameEngine.Common.Primitives;

  public class ObjectLootPileGarbageSpaceship : ProtoObjectLootContainer
  {
    public override double DurationGatheringSeconds => 1;

    public override string InteractionTooltipText => InteractionTooltipTexts.Examine;

    public override bool IsAutoTakeAll => true;

    public override string Name => "Spaceship garbage pile";

    public override ObjectMaterial ObjectMaterial => ObjectMaterial.HardTissues;

    public override double ObstacleBlockDamageCoef => 0.5;

    // It's much easier to find and search these piles so they will provide much less skill experience.
    public override double SearchingSkillExperienceMultiplier => 0.2;

    public override float StructurePointsMax => 0;

    protected override bool CanFlipSprite => true;

    public override Vector2D SharedGetObjectCenterWorldOffset(IWorldObject worldObject)
    {
      return (0.5, 0.3);
    }

    protected override void ClientSetupRenderer(IComponentSpriteRenderer renderer)
    {
      base.ClientSetupRenderer(renderer);
      renderer.DrawOrderOffsetY = 0.5;
    }

    protected override void PrepareLootDroplist(DropItemsList droplist)
    {
      // common loot
      droplist.Add(nestedList:
                   new DropItemsList(outputs: 2)
                       .Add<ItemBallisticPlate>(count: 1, countRandom:2)
                       .Add<ItemStructuralPlating>(count: 1, countRandom: 2)
                       .Add<ItemImpulseEngine>(count: 1, countRandom: 2)
                       .Add<ItemUniversalActuator>(count: 1, countRandom: 2));

      // extra loot
      droplist.Add(condition: SkillSearching.ServerRollExtraLoot,
                   nestedList:
                   new DropItemsList()
                       .Add<ItemComponentsHighTech>(count: 1, countRandom: 2));
    }

    protected override ReadOnlySoundPreset<ObjectSound> PrepareSoundPresetObject()
    {
      return ObjectsSoundsPresets.ObjectGarbagePile;
    }

    protected override double ServerGetDropListRate()
    {
      return RateResourcesGatherCratesLoot.SharedValue;
    }

    protected override void SharedCreatePhysics(CreatePhysicsData data)
    {
      data.PhysicsBody
          .AddShapeCircle(radius: 0.32, center: (0.5, 0.35))
          .AddShapeCircle(radius: 0.35, center: (0.5, 0.35), group: CollisionGroups.ClickArea);
    }
  }
}