﻿namespace AtomicTorch.CBND.CoreMod.Technologies.Tier3.Cooking
{
    using AtomicTorch.CBND.CoreMod.CraftRecipes;

    public class TechNodeArepas : TechNode<TechGroupCookingT3>
    {
        protected override void PrepareTechNode(Config config)
        {
            config.Effects.AddRecipe<RecipeArepas>();

            config.SetRequiredNode<TechNodeSalami>();
        }
    }
}