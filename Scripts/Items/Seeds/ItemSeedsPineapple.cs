namespace AtomicTorch.CBND.CoreMod.Items.Seeds
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Farms;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants;

    public class ItemSeedsPineapple: ProtoItemSeed
    {
        public override string Description =>
            "This seed can be planted to yield a Pineapple.";

        public override string Name => "Pineapple seed";

        protected override void PrepareProtoItemSeed(
            out IProtoObjectVegetation objectPlantProto,
            List<IProtoObjectFarm> allowedToPlaceAt)
        {
            objectPlantProto = GetPlant<ObjectPlantPineapple>();

            allowedToPlaceAt.Add(GetPlot<ObjectFarmPlot>());
        }
    }
}