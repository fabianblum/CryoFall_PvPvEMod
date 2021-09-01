namespace AtomicTorch.CBND.CoreMod.Items.Seeds
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Farms;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants;

    public class ItemSeedsCocaine : ProtoItemSeed
    {
        public override string Description => "Specially prepared coca leaf seeds ready for planting.";

        public override string Name => "Coca Leaf seeds";

        protected override void PrepareProtoItemSeed(
            out IProtoObjectVegetation objectPlantProto,
            List<IProtoObjectFarm> allowedToPlaceAt)
        {
            objectPlantProto = GetPlant<ObjectPlantCocaLeaf>();

            allowedToPlaceAt.Add(GetPlot<ObjectFarmPlot>());
        }
    }
}