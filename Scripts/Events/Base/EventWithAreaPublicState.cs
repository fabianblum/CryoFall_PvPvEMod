namespace AtomicTorch.CBND.CoreMod.Events
{
    using AtomicTorch.CBND.CoreMod.Characters.Player;
    using AtomicTorch.CBND.GameApi.Data.State;
    using AtomicTorch.GameEngine.Common.Primitives;
    using AtomicTorch.CBND.GameApi.Data.State.NetSync;

    public class EventWithAreaPublicState : EventPublicState
    {
        [SyncToClient]
        public Vector2Ushort AreaCirclePosition { get; set; }

        [SyncToClient]
        public ushort AreaCircleRadius { get; set; }

        [SyncToClient]
        public NetworkSyncList<string> BoundToPlayer { get; set; }

        public Vector2Ushort AreaEventOriginalPosition { get; set; }
    }
}