namespace AtomicTorch.CBND.CoreMod.StaticObjects.Structures
{
  using AtomicTorch.CBND.GameApi.Data.Characters;
  using AtomicTorch.CBND.GameApi.Data.State;

  public class StructureWithNpcPrivateState : StructurePrivateState
  {
    [TempOnly]
    public ICharacter NpcCharacter { get; set; }

    [TempOnly]
    public double NpcTimerRespawn { get; set; }

    [TempOnly]
    public bool NpcFirstSpawnDone { get; set; }

  }
}