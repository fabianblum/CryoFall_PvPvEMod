namespace AtomicTorch.CBND.CoreMod.Zones
{
    using System;
    using AtomicTorch.CBND.CoreMod.Characters.Mobs;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Minerals;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Loot;
    using AtomicTorch.CBND.CoreMod.Triggers;

    public class SpawnSulphurSprings : ProtoZoneSpawnScript
    {
        protected override void PrepareZoneSpawnScript(Triggers triggers, SpawnList spawnList)
        {
            triggers
                // trigger on world init
                .Add(GetTrigger<TriggerWorldInit>())
                // trigger on time interval
                // (please note when changing this value to adjust the destruction timeout in ObjectMineralPragmiumNode)
                .Add(GetTrigger<TriggerTimeInterval>().ConfigureForSpawn(TimeSpan.FromMinutes(15)));


            // mineral spawn

            spawnList.CreatePreset(interval: 6, padding: 2.5)
                     .Add<ObjectMineralSulfur>();

            spawnList.CreatePreset(interval: 6, padding: 2.5)
                     .Add<ObjectMineralSaltpeter>();

            // mob spawn
            spawnList.CreatePreset(interval: 18, padding: 0.5)
                     .AddExact<MobCloakedLizard>()
                     .SetCustomPaddingWithSelf(12);
        }
    }
}