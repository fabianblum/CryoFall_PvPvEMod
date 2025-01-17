﻿namespace AtomicTorch.CBND.CoreMod.Zones
{
  using System;
  using AtomicTorch.CBND.CoreMod.Characters.Mobs;
  using AtomicTorch.CBND.CoreMod.Triggers;

  public class SpawnMobsMutantCrawler : ProtoZoneSpawnScript
  {
    protected override void PrepareZoneSpawnScript(Triggers triggers, SpawnList spawnList)
    {
      triggers
          .Add(GetTrigger<TriggerWorldInit>())
          .Add(GetTrigger<TriggerTimeInterval>().ConfigureForSpawn(TimeSpan.FromMinutes(10)));

      spawnList.CreatePreset(interval: 12, padding: 0.5, useSectorDensity: false)
               .AddExact<MobMutantCrawler>()
               .SetCustomPaddingWithSelf(8);
    }
  }
}