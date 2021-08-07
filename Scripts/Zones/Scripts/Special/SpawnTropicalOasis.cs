namespace AtomicTorch.CBND.CoreMod.Zones
{
    using System;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Trees;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Bushes;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Loot;
    using AtomicTorch.CBND.CoreMod.Triggers;

    public class SpawnTropicalOasis : ProtoZoneSpawnScript
    {
        protected override void PrepareZoneSpawnScript(Triggers triggers, SpawnList spawnList)
        {
            triggers
                // trigger on world init
                .Add(GetTrigger<TriggerWorldInit>())
                // trigger on time interval
                // (please note when changing this value to adjust the destruction timeout in ObjectMineralPragmiumNode)
                .Add(GetTrigger<TriggerTimeInterval>().ConfigureForSpawn(TimeSpan.FromMinutes(15)));

            // tree spawn
            spawnList.CreatePreset(interval: 3.5, padding: 1.5)
                                 .Add<ObjectTreePalm>(weight: 2)
                                 .Add<ObjectTreeTropical>(weight: 1)
                                 .SetCustomPaddingWithSelf(1.8);

            // bush spawn
            spawnList.CreatePreset(interval: 4, padding: 1)
                           .Add<ObjectBushCoffee>()
                           .SetCustomPaddingWithSelf(1);

            spawnList.CreatePreset(interval: 8, padding: 1)
                           .Add<ObjectBushWaterbulb>()
                           .SetCustomPaddingWithSelf(8);

            spawnList.CreatePreset(interval: 6, padding: 1)
                           .Add<ObjectBushYucca>()
                           .SetCustomPaddingWithSelf(4);

            // loot spawn
            spawnList.CreatePreset(interval: 6, padding: 0.1)
                     .Add<ObjectLootGrass>()
                     .SetCustomPaddingWithSelf(3);
        }
    }
}