﻿namespace AtomicTorch.CBND.CoreMod.Zones
{
    using System;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Trees;
    using AtomicTorch.CBND.CoreMod.Triggers;

    public class SpawnTreesBoreal : ProtoZoneSpawnScript
    {
        protected override void PrepareZoneSpawnScript(Triggers triggers, SpawnList spawnList)
        {
            triggers
                // trigger on world init
                .Add(GetTrigger<TriggerWorldInit>())
                // trigger on time interval
                .Add(GetTrigger<TriggerTimeInterval>().ConfigureForSpawn(TimeSpan.FromMinutes(15)));

            // regular trees
            var regularTrees = spawnList.CreatePreset(interval: 6.1, padding: 0.8)
                                        .Add<ObjectTreePoplar>()
                                        .SetCustomPaddingWithSelf(3);

            // higher density for pines
            var pines = spawnList.CreatePreset(interval: 3.75, padding: 0.8)
                                 .Add<ObjectTreePineBoreal>()
                                 // not directly near (left, right, etc.), but diagonally - ok!
                                 .SetCustomPaddingWithSelf(1.1);
        }
    }
}