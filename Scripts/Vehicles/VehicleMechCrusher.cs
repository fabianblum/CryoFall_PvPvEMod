﻿namespace AtomicTorch.CBND.CoreMod.Vehicles
{
  using System.Collections.Generic;
  using AtomicTorch.CBND.CoreMod.CharacterSkeletons;
  using AtomicTorch.CBND.CoreMod.ClientComponents.Rendering.Lighting;
  using AtomicTorch.CBND.CoreMod.ItemContainers.Vehicles;
  using AtomicTorch.CBND.CoreMod.Items;
  using AtomicTorch.CBND.CoreMod.Items.Generic;
  using AtomicTorch.CBND.CoreMod.StaticObjects.Explosives;
  using AtomicTorch.CBND.CoreMod.Systems;
  using AtomicTorch.CBND.CoreMod.Systems.Physics;
  using AtomicTorch.CBND.GameApi.Data.Weapons;
  using AtomicTorch.CBND.GameApi.Data.World;
  using AtomicTorch.CBND.GameApi.Scripting;
  using AtomicTorch.GameEngine.Common.Primitives;

  public class VehicleMechCrusher : ProtoVehicleMech
  {
    public override byte CargoItemsSlotsCount => 64;

    public override string Description =>
        "Production oriented mechanized machine.";

    public override ushort EnergyUsePerSecondIdle => 90;

    public override ushort EnergyUsePerSecondMoving => 360;

    public override BaseItemsContainerMechEquipment EquipmentItemsContainerType
        => Api.GetProtoEntity<ContainerMechEquipmentCrusher>();

    public override string Name => "Crusher";

    public override double PhysicsBodyAccelerationCoef => 3;

    public override double PhysicsBodyFriction => 10;

    public override double StatMoveSpeed => 1.9;

    public override float StructurePointsMax => 800;

    public override double VehicleWorldHeight => 2.6;

    public override bool IsBuildableInPvEZone => false;

    protected override void PrepareDefense(DefenseDescription defense)
    {
      defense.Set(
          impact: 0.60,
          kinetic: 0.80,
          explosion: 0.50,
          heat: 0.80,
          cold: 0.50,
          chemical: 1.00,
          radiation: 0.5,
          psi: 0.8);
    }

    protected override void PrepareDismountPoints(List<Vector2D> dismountPoints)
    {
      dismountPoints.Add((0, -0.36));     // down
      dismountPoints.Add((-0.45, -0.36)); // down-left
      dismountPoints.Add((0.45, -0.36));  // down-right
      dismountPoints.Add((0, 0.36));      // up
      dismountPoints.Add((-0.7, 0));      // left
      dismountPoints.Add((0.7, 0));       // right
      dismountPoints.Add((-0.45, 0.36));  // up-left
      dismountPoints.Add((0.45, 0.36));   // up-right
    }

    protected override void PrepareProtoVehicle(
        InputItems buildRequiredItems,
        InputItems repairStageRequiredItems,
        out int repairStagesCount)
    {
      buildRequiredItems
          .Add<ItemStructuralPlating>(40)
          .Add<ItemUniversalActuator>(10)
          .Add<ItemImpulseEngine>(8)
          .Add<ItemComponentsHighTech>(25)
          .Add<ItemCanisterMineralOil>(10)
          .Add<ItemFlowerYellow>(20);

      repairStageRequiredItems
          .Add<ItemIngotSteel>(20)
          .Add<ItemStructuralPlating>(1)
          .Add<ItemUniversalActuator>(1)
          .Add<ItemComponentsHighTech>(1);

      repairStagesCount = 5;
    }

    protected override void PrepareProtoVehicleDestroyedExplosionPreset(
        out double damageRadius,
        out ExplosionPreset explosionPreset,
        out DamageDescription damageDescriptionCharacters)
    {
      damageRadius = 2.1;
      explosionPreset = ExplosionPresets.VeryLarge;

      damageDescriptionCharacters = new DamageDescription(
          damageValue: 75,
          armorPiercingCoef: 0.25,
          finalDamageMultiplier: 1,
          rangeMax: damageRadius,
          damageDistribution: new DamageDistribution(DamageType.Explosion, 1));
    }

    protected override void PrepareProtoVehicleLightConfig(ItemLightConfig lightConfig)
    {
      lightConfig.Color = LightColors.Flashlight;
      lightConfig.ScreenOffset = (3, -2);
      lightConfig.WorldOffset = (0, -0.5);
      lightConfig.Size = 23;
    }

    protected override void SharedCreatePhysics(CreatePhysicsData data)
    {
      base.SharedCreatePhysics(data);

      var physicsBody = data.PhysicsBody;
      if (data.PublicState.PilotCharacter is null)
      {
        // no pilot
        physicsBody.AddShapeRectangle(size: (0.9, 1.5),
                                      offset: (-0.45, -0.4),
                                      group: CollisionGroups.ClickArea);
      }
    }

    protected override void SharedGetSkeletonProto(
        IDynamicWorldObject gameObject,
        out ProtoCharacterSkeleton protoSkeleton,
        ref double scale)
    {
      protoSkeleton = Api.GetProtoEntity<SkeletonMechCrusher>();
    }
  }
}