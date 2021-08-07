namespace AtomicTorch.CBND.CoreMod.Zones
{
    using System;
    using AtomicTorch.CBND.CoreMod.Characters.Mobs;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Minerals;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Loot;
    using AtomicTorch.CBND.CoreMod.Triggers;

    public class SpawnParalithBarren : ProtoZoneSpawnScript
    {
        protected override void PrepareZoneSpawnScript(Triggers triggers, SpawnList spawnList)
        {
            triggers
                // trigger on world init
                .Add(GetTrigger<TriggerWorldInit>())
                // trigger on time interval
                // (please note when changing this value to adjust the destruction timeout in ObjectMineralPragmiumNode)
                .Add(GetTrigger<TriggerTimeInterval>().ConfigureForSpawn(TimeSpan.FromMinutes(10)));

            // mineral spawn
            spawnList.CreatePreset(interval: 90, padding: 0.5)
                     .Add<ObjectMineralPragmiumNode>()
                     .SetCustomPaddingWithSelf(69);

            // loot spawn
            spawnList.CreatePreset(interval: 16, padding: 1)
                     .Add<ObjectLootPileGarbage1>()
                     .Add<ObjectLootPileGarbage2>()
                     .SetCustomPaddingWithSelf(36);

            // mob spawn
            var presetScorpion = spawnList.CreatePreset(interval: 160, padding: 1.5)
                                        .AddExact<MobScorpion>()
                                        .SetCustomPaddingWithSelf(79);

            var presetSpitter = spawnList.CreatePreset(interval: 170, padding: 1.5)
                                        .AddExact<MobSpitter>()
                                        .SetCustomPaddingWithSelf(79);

            // define custom spawn padding between different mobs
            presetScorpion.SetCustomPaddingWith(presetSpitter, 79);
        }
    }
}