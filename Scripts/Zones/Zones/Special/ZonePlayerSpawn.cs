namespace AtomicTorch.CBND.CoreMod.Zones
{
  using AtomicTorch.CBND.GameApi;

  public class ZonePlayerSpawn : ProtoZoneDefault
  {
    public static ZonePlayerSpawn Instance { get; private set; }

    [NotLocalizable]
    public override string Name => "Special - Player Spwan Zone";

    protected override void PrepareZone(ZoneScripts scripts)
    {
        // Special zone - no logic here, it is handled by external implementation
        // Used to restrict building in certain map areas.
        Instance = this;
    }

  }
}