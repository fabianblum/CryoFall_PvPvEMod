namespace AtomicTorch.CBND.CoreMod.Items.Seeds
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Farms;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants;

    public class ItemSeedsMushroomPennyBun : ProtoItemSeed
    {
        public override string Description =>
            "This spore can be planted to yield a Penny Bun Mushroom.";

        public override string Name => "Penny bun spore";

        protected override void PrepareProtoItemSeed(
            out IProtoObjectVegetation objectPlantProto,
            List<IProtoObjectFarm> allowedToPlaceAt)
        {
            objectPlantProto = GetPlant<ObjectPlantMushroomPennyBun>();

            allowedToPlaceAt.Add(GetPlot<ObjectFarmPlot>());
        }
    }
}