namespace AtomicTorch.CBND.CoreMod.Zones
{
    using AtomicTorch.CBND.GameApi;

    public class ZoneTropicalCoastOcean : ProtoZoneDefault
    {
        [NotLocalizable]
        public override string Name => "Tropical - Coast - Ocean";

        protected override void PrepareZone(ZoneScripts scripts)
        {
            // trees
            scripts
                .Add(GetScript <SpawnTropicalCoastOcean>());
            // minerals
            scripts
                .Add(GetScript<SpawnResourceSand>());

            // loot
            scripts
                .Add(GetScript<SpawnLootCoasts>())
                .Add(GetScript<SpawnLootStone>())
                .Add(GetScript<SpawnLootTwigs>());

            // mobs
            scripts
                .Add(GetScript<SpawnMobsCrab>())
                .Add(GetScript<SpawnMobsStarfish>())
                .Add(GetScript<SpawnMobsTurtle>());
        }
    }
}