namespace AtomicTorch.CBND.CoreMod.Items.Seeds
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Farms;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants;

    public class ItemSeedsMushroomPink: ProtoItemSeed
    {
        public override string Description =>
            "This spore can be planted to yield a Pink Mushroom.";

        public override string Name => "Pink mushroom spore";

        protected override void PrepareProtoItemSeed(
            out IProtoObjectVegetation objectPlantProto,
            List<IProtoObjectFarm> allowedToPlaceAt)
        {
            objectPlantProto = GetPlant<ObjectPlantMushroomPink>();

            allowedToPlaceAt.Add(GetPlot<ObjectFarmPlot>());
        }
    }
}