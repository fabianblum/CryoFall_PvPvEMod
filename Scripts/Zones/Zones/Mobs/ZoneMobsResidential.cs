namespace AtomicTorch.CBND.CoreMod.Zones
{
    using AtomicTorch.CBND.GameApi;

    public class ZoneMobsResidential : ProtoZoneDefault
    {
        [NotLocalizable]
        public override string Name => "Mobs - Residential";

        protected override void PrepareZone(ZoneScripts scripts)
        {
            scripts
                .Add(GetScript<SpawnMobsCrawler>())
                .Add(GetScript<SpawnMobsWolf>().Configure(densityMultiplier: 3))
                .Add(GetScript<SpawnMobsChicken>())
                .Add(GetScript<SpawnMobsBear>().Configure(densityMultiplier: 0.9));
        }
    }
}