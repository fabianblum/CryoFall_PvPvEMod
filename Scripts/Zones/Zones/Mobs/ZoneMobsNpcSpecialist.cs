namespace AtomicTorch.CBND.CoreMod.Zones
{
    using AtomicTorch.CBND.GameApi;

    public class ZoneMobsNpcSpecialist : ProtoZoneDefault
    {
        [NotLocalizable]
        public override string Name => "Mobs - NPC Specialist";

        protected override void PrepareZone(ZoneScripts scripts)
        {
            scripts
                .Add(GetScript<SpawnMobsNpcSpecialist>().Configure(densityMultiplier: 2));
        }
    }
}