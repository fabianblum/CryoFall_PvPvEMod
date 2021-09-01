namespace AtomicTorch.CBND.CoreMod.Items.Seeds
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Farms;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants;

    public class ItemSeedsHerbBlue : ProtoItemSeed
    {
        public override string Description => "Can be planted to grow blue herbs.";

        public override string Name => "Blue herb seeds";

        protected override void PrepareProtoItemSeed(
            out IProtoObjectVegetation objectPlantProto,
            List<IProtoObjectFarm> allowedToPlaceAt)
        {
            objectPlantProto = GetPlant<ObjectPlantHerbBlue>();

            allowedToPlaceAt.Add(GetPlot<ObjectFarmPlot>());
            allowedToPlaceAt.Add(GetPlot<ObjectPlantPot>());
        }
    }
}