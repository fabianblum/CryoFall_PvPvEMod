namespace AtomicTorch.CBND.CoreMod.Zones
{
    using System;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Loot;
    using AtomicTorch.CBND.CoreMod.Triggers;

    public class SpawnLootBoreal : ProtoZoneSpawnScript
    {
        protected override void PrepareZoneSpawnScript(Triggers triggers, SpawnList spawnList)
        {
            triggers
                // trigger on world init
                .Add(GetTrigger<TriggerWorldInit>())
                // trigger on time interval
                .Add(GetTrigger<TriggerTimeInterval>().ConfigureForSpawn(TimeSpan.FromMinutes(5)));

            // grass
            spawnList.CreatePreset(interval: 8, padding: 0.1)
                     .Add<ObjectLootGrass>()
                     .SetCustomPaddingWithSelf(3);

            // twigs
            spawnList.CreatePreset(interval: 6, padding: 0.1)
                     .Add<ObjectLootTwigs>()
                     .SetCustomPaddingWithSelf(2);

            // stones
            spawnList.CreatePreset(interval: 10, padding: 0.1)
                     .Add<ObjectLootStone>()
                     .SetCustomPaddingWithSelf(4);
        }
    }
}