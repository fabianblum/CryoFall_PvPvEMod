namespace AtomicTorch.CBND.CoreMod.Zones
{
    using System;
    using AtomicTorch.CBND.CoreMod.Characters.Mobs;
    using AtomicTorch.CBND.CoreMod.Triggers;

    public class SpawnBossIsland : ProtoZoneSpawnScript
    {
        protected override void PrepareZoneSpawnScript(Triggers triggers, SpawnList spawnList)
        {
            triggers
                // trigger on world init
                .Add(GetTrigger<TriggerWorldInit>())
                // trigger on time interval
                // (please note when changing this value to adjust the destruction timeout in ObjectMineralPragmiumNode)
                .Add(GetTrigger<TriggerTimeInterval>().ConfigureForSpawn(TimeSpan.FromMinutes(15)));

            // mob spawn
            var presetSpitter = spawnList.CreatePreset(interval: 1, padding: 0.5)
                                          .AddExact<MobSpitter>()
                                          .SetCustomPaddingWithSelf(60);

            var presetScorpion = spawnList.CreatePreset(interval: 1, padding: 0.5)
                                        .AddExact<MobScorpion>()
                                        .SetCustomPaddingWithSelf(60);

            var presetBlackBeetle = spawnList.CreatePreset(interval: 1, padding: 0.5)
                                        .AddExact<MobBlackBeetle>()
                                        .SetCustomPaddingWithSelf(30);

            // define custom spawn padding between different mobs
            presetSpitter.SetCustomPaddingWith(presetScorpion, 60);
            presetSpitter.SetCustomPaddingWith(presetBlackBeetle, 30);
            presetScorpion.SetCustomPaddingWith(presetBlackBeetle, 30);
        }
    }
}