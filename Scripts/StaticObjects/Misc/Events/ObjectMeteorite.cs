﻿namespace AtomicTorch.CBND.CoreMod.StaticObjects.Misc.Events
{
  using AtomicTorch.CBND.CoreMod.Characters.Player;
  using AtomicTorch.CBND.CoreMod.Events;
  using AtomicTorch.CBND.CoreMod.Items.Generic;
  using AtomicTorch.CBND.CoreMod.Rates;
  using AtomicTorch.CBND.CoreMod.Skills;
  using AtomicTorch.CBND.CoreMod.SoundPresets;
  using AtomicTorch.CBND.CoreMod.StaticObjects.Minerals;
  using AtomicTorch.CBND.CoreMod.Systems.Droplists;
  using AtomicTorch.CBND.CoreMod.Systems.Physics;
  using AtomicTorch.CBND.CoreMod.Systems.PvE;
  using AtomicTorch.CBND.CoreMod.Technologies;
  using AtomicTorch.CBND.GameApi.Data.Characters;
  using AtomicTorch.CBND.GameApi.Data.World;
  using AtomicTorch.CBND.GameApi.Scripting;
  using AtomicTorch.CBND.GameApi.ServicesClient.Components;
  using AtomicTorch.GameEngine.Common.Primitives;
  using System.Linq;

  public class ObjectMeteorite : ProtoObjectMineralMeteorite
  {
    private const int WorldOffsetY = 2;

    public override string Name => "Meteorite";

    public override ObjectMaterial ObjectMaterial => ObjectMaterial.Stone;

    public override double ObstacleBlockDamageCoef => 0.5;

    public override double ServerCooldownDuration
        => PveSystem.ServerIsPvE
               ? 0        // in PvE can mine instantly (first come first serve)
               : 10 * 60; // 10 minutes in PvP

    public override float StructurePointsMax => 3000;

    public override string TextureAtlasPath => "StaticObjects/Misc/Events/ObjectMeteorite";

    // assume all the meteorites fall with the same angle so they have similar appearance
    protected override bool CanFlipSprite => false;

    public override Vector2D SharedGetObjectCenterWorldOffset(IWorldObject worldObject)
    {
      return base.SharedGetObjectCenterWorldOffset(worldObject) + (0, WorldOffsetY);
    }

    protected override void ClientSetupRenderer(IComponentSpriteRenderer renderer)
    {
      base.ClientSetupRenderer(renderer);
      renderer.PositionOffset = (211 / 256.0, WorldOffsetY + 130 / 256.0);
      renderer.DrawOrderOffsetY += WorldOffsetY;
    }

    protected override void CreateLayout(StaticObjectLayout layout)
    {
      // extra space below is used to ensure that the object will be not obscured by trees
      layout.Setup("###",
                   "###",
                   "###",
                   "###");
    }

    protected override void PrepareProtoMineral(MineralDropItemsConfig config)
    {
      // droplist for stage 1
      config.Stage1
            .Add<ItemOreCopperConcentrate>(count: 5)
            .Add<ItemOreCopperConcentrate>(countRandom: 2, condition: SkillProspecting.ConditionAdditionalYield)
            .Add<ItemOreIronConcentrate>(count: 5)
            .Add<ItemOreIronConcentrate>(countRandom: 2, condition: SkillProspecting.ConditionAdditionalYield)
            .Add<ItemGoldNugget>(count: 1);

      // droplist for stages 2 and 3 - reuse droplist from stage 1
      config.Stage2.Add(config.Stage1);
      config.Stage3.Add(config.Stage1);

      // droplist for stage 4
      config.Stage4
            .Add<ItemOreCopperConcentrate>(count: 10)
            .Add<ItemOreCopperConcentrate>(countRandom: 2, condition: SkillProspecting.ConditionAdditionalYield)
            .Add<ItemOreIronConcentrate>(count: 10)
            .Add<ItemOreIronConcentrate>(countRandom: 2, condition: SkillProspecting.ConditionAdditionalYield)
            .Add<ItemGoldNugget>(count: 2)
            .Add<ItemGoldNugget>(countRandom: 1, condition: SkillProspecting.ConditionAdditionalYield)
            .Add<ItemGoldNugget>(count: 3, condition: T4SpecializedPvPOnly)
            .Add<ItemGoldNugget>(count: 3, condition: T5SpecializedPvPOnly);

      static bool T4SpecializedPvPOnly(DropItemContext context)
          => !PveSystem.ServerIsPvE
             && ServerTechTimeGateHelper.IsAvailableT4Specialized(context);

      static bool T5SpecializedPvPOnly(DropItemContext context)
          => !PveSystem.ServerIsPvE
             && ServerTechTimeGateHelper.IsAvailableT5Specialized(context);
    }

    protected override double ServerGetDropListProbabilityMultiplier(IStaticWorldObject mineralObject)
    {
      return RateResourcesGatherMeteorites.SharedValue;
    }

    protected override void ServerInitialize(ServerInitializeData data)
    {
      base.ServerInitialize(data);

      if (data.IsFirstTimeInit
          && !data.GameObject.OccupiedTile.StaticObjects
                  .Any(o => o.ProtoGameObject is ObjectCrater))
      {
        Server.World.CreateStaticWorldObject<ObjectCrater>(
            (data.GameObject.TilePosition + (0, WorldOffsetY)).ToVector2Ushort());
      }
    }

    protected override void ServerOnMineralStageMined(ICharacter character, IStaticWorldObject mineralObject)
    {
      //MOD - damaged by meteor
      if (character is null)
        return;

      PlayerCharacter.GetPrivateState(character)
                     .CompletionistData
                     .ServerOnParticipatedInEvent(Api.GetProtoEntity<EventMeteoriteDrop>());
    }

    protected override void SharedCreatePhysics(CreatePhysicsData data)
    {
      var y = WorldOffsetY;
      data.PhysicsBody
          .AddShapeRectangle(size: (1, 0.5), offset: (1.0, y + 0.65))
          .AddShapeRectangle(size: (0.9, 0.8), offset: (1.05, y + 0.6), group: CollisionGroups.HitboxMelee)
          .AddShapeRectangle(size: (0.8, 0.15), offset: (1.1, y + 1.35), group: CollisionGroups.HitboxRanged)
          .AddShapeLineSegment(point1: (1.5, 0.7), point2: (1.5, y + 1.35), group: CollisionGroups.HitboxRanged)
          // click area is necessary to display the message on mouse hover
          .AddShapeRectangle(size: (0.9, 0.8), offset: (1.05, y + 0.6), group: CollisionGroups.ClickArea);
    }
  }
}