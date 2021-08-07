namespace AtomicTorch.CBND.CoreMod.Zones
{
    using AtomicTorch.CBND.GameApi;

    public class ZoneMobsScorpions : ProtoZoneDefault
    {
        [NotLocalizable]
        public override string Name => "Mobs - Scorpions";

        protected override void PrepareZone(ZoneScripts scripts)
        {
            scripts
                .Add(GetScript<SpawnMobsScorpion>().Configure(densityMultiplier: 2));
        }
    }
}