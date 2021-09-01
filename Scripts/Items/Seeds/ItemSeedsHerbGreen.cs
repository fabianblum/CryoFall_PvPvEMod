namespace AtomicTorch.CBND.CoreMod.Items.Seeds
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Farms;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants;

    public class ItemSeedsHerbGreen : ProtoItemSeed
    {
        public override string Description => "Can be planted to grow green herbs.";

        public override string Name => "Green herb seeds";

        protected override void PrepareProtoItemSeed(
            out IProtoObjectVegetation objectPlantProto,
            List<IProtoObjectFarm> allowedToPlaceAt)
        {
            objectPlantProto = GetPlant<ObjectPlantHerbGreen>();

            allowedToPlaceAt.Add(GetPlot<ObjectFarmPlot>());
            allowedToPlaceAt.Add(GetPlot<ObjectPlantPot>());
        }
    }
}