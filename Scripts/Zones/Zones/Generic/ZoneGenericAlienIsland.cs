namespace AtomicTorch.CBND.CoreMod.Zones
{
    using AtomicTorch.CBND.GameApi;

    public class ZoneGenericAlienIsland : ProtoZoneDefault
    {
        [NotLocalizable]
        public override string Name => "Generic - Alien island";

        protected override void PrepareZone(ZoneScripts scripts)
        {
            // shrubs, minerals and mobs
            scripts
                .Add(GetScript<SpawnAlienIsland>());
        }
    }
}