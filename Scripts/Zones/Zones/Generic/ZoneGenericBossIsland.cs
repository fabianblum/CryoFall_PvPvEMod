namespace AtomicTorch.CBND.CoreMod.Zones
{
    using AtomicTorch.CBND.GameApi;

    public class ZoneGenericBossIsland : ProtoZoneDefault
    {
        [NotLocalizable]
        public override string Name => "Generic - Boss island";

        protected override void PrepareZone(ZoneScripts scripts)
        {
            // plants
            scripts
                .Add(GetScript<SpawnTreesBarren>())
                .Add(GetScript<SpawnBushesBarren>())
                .Add(GetScript<SpawnShrubs>());

            // minerals
            scripts
                .Add(GetScript<SpawnResourcePragmium>())
                .Add(GetScript<SpawnResourceCopper>().Configure(densityMultiplier: 0.10))
                .Add(GetScript<SpawnResourceIron>().Configure(densityMultiplier: 0.10))
                .Add(GetScript<SpawnResourceStone>().Configure(densityMultiplier: 0.10))
                .Add(GetScript<SpawnResourceSaltpeter>().Configure(densityMultiplier: 0.10))
                .Add(GetScript<SpawnResourceSulfur>().Configure(densityMultiplier: 0.10));

            // mobs
            scripts
                .Add(GetScript<SpawnBossIsland>());
        }
    }
}