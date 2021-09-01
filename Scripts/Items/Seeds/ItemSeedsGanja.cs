namespace AtomicTorch.CBND.CoreMod.Items.Seeds
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Farms;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants;

    public class ItemSeedsGanja : ProtoItemSeed
    {
        public override string Description => "Specially prepared ganja leaf seeds ready for planting.";

        public override string Name => "Ganja Leaf seeds";

        protected override void PrepareProtoItemSeed(
            out IProtoObjectVegetation objectPlantProto,
            List<IProtoObjectFarm> allowedToPlaceAt)
        {
            objectPlantProto = GetPlant<ObjectPlantGanjaLeaf>();

            allowedToPlaceAt.Add(GetPlot<ObjectFarmPlot>());
        }
    }
}