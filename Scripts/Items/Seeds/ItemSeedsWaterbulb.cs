namespace AtomicTorch.CBND.CoreMod.Items.Seeds
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Farms;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants;

    public class ItemSeedsWaterbulb : ProtoItemSeed
    {
        public override string Description => "Waterbulb seeds prepared for planting.";

        public override string Name => "Waterbulb seeds.";

        protected override void PrepareProtoItemSeed(
            out IProtoObjectVegetation objectPlantProto,
            List<IProtoObjectFarm> allowedToPlaceAt)
        {
            objectPlantProto = GetPlant<ObjectPlantWaterbulb>();

            allowedToPlaceAt.Add(GetPlot<ObjectFarmPlot>());
        }
    }
}