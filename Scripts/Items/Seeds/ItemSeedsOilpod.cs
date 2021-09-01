namespace AtomicTorch.CBND.CoreMod.Items.Seeds
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Farms;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants;

    public class ItemSeedsOilpod : ProtoItemSeed
    {
        public override string Description => "Oilpods actually have seeds if you look hard enough.";

        public override string Name => "Oilpod seeds.";

        protected override void PrepareProtoItemSeed(
            out IProtoObjectVegetation objectPlantProto,
            List<IProtoObjectFarm> allowedToPlaceAt)
        {
            objectPlantProto = GetPlant<ObjectPlantOilpod>();

            allowedToPlaceAt.Add(GetPlot<ObjectFarmPlot>());
        }
    }
}