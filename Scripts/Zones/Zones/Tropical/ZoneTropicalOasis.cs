namespace AtomicTorch.CBND.CoreMod.Zones
{
    using AtomicTorch.CBND.GameApi;

    public class ZoneTropicalOasis : ProtoZoneDefault
    {
        [NotLocalizable]
        public override string Name => "Tropical - Oasis";

        protected override void PrepareZone(ZoneScripts scripts)
        {
            // trees, mobs, and loot
            scripts
                .Add(GetScript<SpawnTropicalOasis>());
        }
    }
}