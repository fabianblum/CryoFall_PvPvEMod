namespace AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations
{
  using AtomicTorch.CBND.CoreMod.Characters;
  using AtomicTorch.CBND.CoreMod.Systems.Physics;
  using AtomicTorch.CBND.GameApi.Data.Characters;
  using AtomicTorch.CBND.GameApi.Extensions;
  using AtomicTorch.CBND.GameApi.Scripting;
  using AtomicTorch.GameEngine.Common.Helpers;
  using AtomicTorch.GameEngine.Common.Primitives;
  using System;
  using System.Collections.Generic;

  public abstract class ProtoObjectCraftStationWithNpc
      <TPrivateState,
       TPublicState,
       TClientState>
      : ProtoObjectCraftStation
        <TPrivateState,
            TPublicState,
            TClientState>
      where TPrivateState : StructureWithNpcPrivateState, new()
      where TPublicState : StaticObjectPublicState, new()
      where TClientState : StaticObjectClientState, new()
  {
    abstract protected IProtoCharacter NPC { get; }

    public override double ServerUpdateIntervalSeconds => 1;

    // If the mob is too far away from the spawn position, it should be despawned after the delay.
    private const int DespawnTileDistanceThreshold = 5; // lowered for testing, default will be 20+ tiles away

    private const int NpcRespawnTimeThreshold = 5; // lowered for testing, default will be 10 minutes (10 * 60)

    protected virtual bool IsAutoDespawn => true;

    public object ServerWorld { get; private set; }

    // ReSharper disable once StaticMemberInGenericType
    private static readonly List<ICharacter> TempListPlayersInView = new();

    protected override void ServerUpdate(ServerUpdateData data)
    {
      base.ServerUpdate(data);

      var privateState = data.PrivateState as StructureWithNpcPrivateState;
      bool isDead = true;
      if (privateState.NpcCharacter is not null)
      {
        if (privateState.NpcCharacter.IsDestroyed)
        {
          isDead = true;
        }
        else
        {
          var npcPublicState = privateState.NpcCharacter.GetPublicState<CharacterMobPublicState>();
          isDead = npcPublicState.IsDead;
        }     
      }

      if (isDead)
      {
        // check respawn timer
        if (privateState.NpcFirstSpawnDone && privateState.NpcTimerRespawn < NpcRespawnTimeThreshold)
        {
          // delay is not finished yet
          privateState.NpcTimerRespawn += data.DeltaTime;
          return;
        }

        var offset = this.SharedGetObjectCenterWorldOffset(data.GameObject);
        var center = data.GameObject.TilePosition.ToVector2D() + offset;
        var radius = offset.Length;
        privateState.NpcCharacter = ServerSpawnNpc(center.ToVector2Ushort(), this.NPC, radius * 0.5);

        if (privateState.NpcCharacter is not null)
        {
          privateState.NpcTimerRespawn = 0;
          privateState.NpcFirstSpawnDone = true;
        }
      }
      else
      {
        this.ServerDespawnNpc(privateState.NpcCharacter, privateState, data);
      }
    }

    public static ICharacter ServerSpawnNpc(Vector2Ushort centerPosition, IProtoCharacter protoCharacter, double radius)
    {
      var attemptsRemains = 300;

      while (attemptsRemains > 0)
      {
        attemptsRemains--;

        // calculate random distance
        var distance = RandomHelper.Range(0, radius);

        // ensure we spawn more objects closer to the epicenter
        var spawnProbability = 1 - (distance / radius);
        spawnProbability = Math.Pow(spawnProbability, 1.25);
        if (!RandomHelper.RollWithProbability(spawnProbability))
        {
          // random skip
          continue;
        }

        var angle = RandomHelper.NextDouble() * MathConstants.DoublePI;
        var spawnPosition = new Vector2D(
            centerPosition.X + 1.25 + distance * Math.Cos(angle),
            centerPosition.Y + distance * Math.Sin(angle));

        var spawnedCharacter = ServerTrySpawn(spawnPosition);
        if (spawnedCharacter is not null)
        {
          // spawned successfully!
          return spawnedCharacter;
        }
      }

      return null;

      ICharacter ServerTrySpawn(Vector2D worldPosition)
      {
        if (!ServerCharacterSpawnHelper.IsValidSpawnPosition(worldPosition))
        {
          // position is not valid for spawning
          return null;
        }

        var physicsSpace = Api.Server.World.GetPhysicsSpace();

        // check if any physics object nearby
        using (var objectsNearby = physicsSpace.TestCircle(worldPosition, 0.1, CollisionGroups.Default, sendDebugEvent: false))
        {
          if (objectsNearby.Count > 0)
          {
            // some physical object nearby
            return null;
          }
        }

        var spawnedCharacter = Api.Server.Characters.SpawnCharacter(protoCharacter, worldPosition);
        return spawnedCharacter;
      }
    }

    private void ServerDespawnNpc(ICharacter characterMob, StructureWithNpcPrivateState privateState, ServerUpdateData data)
    {
      if (!this.IsAutoDespawn)
        return;

      if (characterMob is null || characterMob.IsDestroyed)
        return;

      var distanceToSpawnSqr = data.GameObject.TilePosition.TileSqrDistanceTo(characterMob.TilePosition);
      if (distanceToSpawnSqr < DespawnTileDistanceThreshold * DespawnTileDistanceThreshold)
        return;

      // should despawn
      // check that nobody is observing the mob
      var playersInView = TempListPlayersInView;
      playersInView.Clear();
      Api.Server.World.GetCharactersInView(characterMob,
                                      playersInView,
                                      onlyPlayerCharacters: true);

      foreach (var playerCharacter in playersInView)
      {
        if (playerCharacter.ServerIsOnline)
        {
          // cannot despawn - scoped by a player
          return;
        }
      }

      // nobody is observing, can despawn
      Logger.Important("Mob despawned as it went too far from the spawn position for too long: " + characterMob);
      Api.Server.World.DestroyObject(characterMob);
    }
  }

  public abstract class ProtoObjectCraftStationWithNpc
      : ProtoObjectCraftStationWithNpc
          <StructureWithNpcPrivateState,
              StaticObjectPublicState,
              StaticObjectClientState>
  {
  }
}