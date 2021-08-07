namespace AtomicTorch.CBND.CoreMod.Zones
{
  using AtomicTorch.CBND.GameApi;

  public class ZonePvE : ProtoZoneDefault
  {
    public static ZonePvE Instance { get; private set; }

    [NotLocalizable]
    public override string Name => "Special - PvE Zone";

    protected override void PrepareZone(ZoneScripts scripts)
    {
        // Special zone - no logic here, it is handled by external implementation
        // Used to restrict building in certain map areas.
        Instance = this;
    }

  }
}