namespace AtomicTorch.CBND.CoreMod.Zones
{
    using System;
    using AtomicTorch.CBND.CoreMod.Characters.Mobs;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Trees;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Minerals;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Bushes;
    using AtomicTorch.CBND.CoreMod.Triggers;

    public class SpawnAlienIsland : ProtoZoneSpawnScript
    {
        protected override void PrepareZoneSpawnScript(Triggers triggers, SpawnList spawnList)
        {
            triggers
                // trigger on world init
                .Add(GetTrigger<TriggerWorldInit>())
                // trigger on time interval
                // (please note when changing this value to adjust the destruction timeout in ObjectMineralPragmiumNode)
                .Add(GetTrigger<TriggerTimeInterval>().ConfigureForSpawn(TimeSpan.FromMinutes(15)));

            // trees spawn
            spawnList.CreatePreset(interval: 8, padding: 0.5)
                     .Add<ObjectTreeSwamp>()
                     .Add<ObjectTreeWillow>()
                     .Add<ObjectTreeBrevifolia>()
                     .SetCustomPaddingWithSelf(3);

            spawnList.CreatePreset(interval: 10, padding: 0.5, useSectorDensity: false)
                     .AddExact<MobPsiGrove>()
                     .SetCustomPaddingWithSelf(15);

            // mineral spawn
            spawnList.CreatePreset(interval: 6, padding: 0.5)
                     .Add<ObjectMineralSand>()
                     .SetCustomPaddingWithSelf(2);

            spawnList.CreatePreset(interval: 20, padding: 0.5)
                     .Add<ObjectMineralSalt>()
                     .SetCustomPaddingWithSelf(5);

            // bush spawn
            spawnList.CreatePreset(interval: 20, padding: 1)
                     .Add<ObjectBushOilpod>()
                     .SetCustomPaddingWithSelf(5);

            // mob spawn
            var presetFloater = spawnList.CreatePreset(interval: 1, padding: 0.5)
                                        .AddExact<MobFloater>()
                                        .SetCustomPaddingWithSelf(79);

            var presetSpitter = spawnList.CreatePreset(interval: 1, padding: 0.5)
                                        .AddExact<MobSpitter>()
                                        .SetCustomPaddingWithSelf(50);

            var presetBurrower = spawnList.CreatePreset(interval: 1, padding: 0.5)
                                        .AddExact<MobBurrower>()
                                        .SetCustomPaddingWithSelf(30);

            var presetCrawler = spawnList.CreatePreset(interval: 1, padding: 0.5)
                                        .AddExact<MobCrawler>()
                                        .SetCustomPaddingWithSelf(20);

            // define custom spawn padding between different mobs
            presetFloater.SetCustomPaddingWith(presetSpitter, 25);
            presetFloater.SetCustomPaddingWith(presetBurrower, 10);
            presetFloater.SetCustomPaddingWith(presetCrawler, 5);
            presetSpitter.SetCustomPaddingWith(presetBurrower, 10);
            presetSpitter.SetCustomPaddingWith(presetCrawler, 5);
            presetBurrower.SetCustomPaddingWith(presetCrawler, 5);
        }
    }
}