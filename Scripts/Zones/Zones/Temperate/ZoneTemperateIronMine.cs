namespace AtomicTorch.CBND.CoreMod.Zones
{
    using AtomicTorch.CBND.GameApi;

    public class ZoneTemperateIronMine : ProtoZoneDefault
    {
        [NotLocalizable]
        public override string Name => "Temperate - Iron mine";

        protected override void PrepareZone(ZoneScripts scripts)
        {
            // minerals and mobs
            scripts
                .Add(GetScript<SpawnIronMine>());
        }
    }
}