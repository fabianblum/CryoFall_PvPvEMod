namespace AtomicTorch.CBND.CoreMod.Zones
{
    using AtomicTorch.CBND.GameApi;

    public class ZoneTemperateSulphurSprings : ProtoZoneDefault
    {
        [NotLocalizable]
        public override string Name => "Temperate - Sulphur Springs";

        protected override void PrepareZone(ZoneScripts scripts)
        {
            // minerals, mobs
            scripts
                .Add(GetScript<SpawnSulphurSprings>());
        }
    }
}