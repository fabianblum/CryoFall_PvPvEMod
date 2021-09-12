namespace AtomicTorch.CBND.CoreMod.Zones
{
    using AtomicTorch.CBND.CoreMod.Characters.Mobs;
    using AtomicTorch.CBND.CoreMod.Triggers;
    using System;

    public class SpawnMobsNpcSpecialist : ProtoZoneSpawnScript
    {
        protected override void PrepareZoneSpawnScript(Triggers triggers, SpawnList spawnList)
        {
            triggers
                .Add(GetTrigger<TriggerWorldInit>())
                .Add(GetTrigger<TriggerTimeInterval>().ConfigureForSpawn(TimeSpan.FromMinutes(5)));

            spawnList.CreatePreset(interval: 18, padding: 1.5, useSectorDensity: false)
                     .AddExact<MobNPC_BA_Specialist>()
                     .SetCustomPaddingWithSelf(3);
        }

    }
}