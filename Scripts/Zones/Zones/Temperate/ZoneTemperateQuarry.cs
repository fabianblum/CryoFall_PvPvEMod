namespace AtomicTorch.CBND.CoreMod.Zones
{
    using AtomicTorch.CBND.GameApi;

    public class ZoneTemperateQuarry : ProtoZoneDefault
    {
        [NotLocalizable]
        public override string Name => "Temperate - Quarry";

        protected override void PrepareZone(ZoneScripts scripts)
        {
            // minerals, mobs, and loot
            scripts
                .Add(GetScript<SpawnQuarry>());
        }
    }
}