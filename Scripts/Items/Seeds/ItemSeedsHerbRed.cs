namespace AtomicTorch.CBND.CoreMod.Items.Seeds
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Farms;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants;

    public class ItemSeedsHerbRed : ProtoItemSeed
    {
        public override string Description => "Can be planted to grow red herbs.";

        public override string Name => "Red herb seeds";

        protected override void PrepareProtoItemSeed(
            out IProtoObjectVegetation objectPlantProto,
            List<IProtoObjectFarm> allowedToPlaceAt)
        {
            objectPlantProto = GetPlant<ObjectPlantHerbRed>();

            allowedToPlaceAt.Add(GetPlot<ObjectFarmPlot>());
            allowedToPlaceAt.Add(GetPlot<ObjectPlantPot>());
        }
    }
}