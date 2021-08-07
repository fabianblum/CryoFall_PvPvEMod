namespace AtomicTorch.CBND.CoreMod.Systems.PveZone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AtomicTorch.CBND.CoreMod.Zones;
    using AtomicTorch.CBND.GameApi;
    using AtomicTorch.CBND.GameApi.Data;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using JetBrains.Annotations;
    using AtomicTorch.CBND.CoreMod.Helpers.Client;
    using System.Diagnostics.CodeAnalysis;
    using AtomicTorch.CBND.CoreMod.Items.Tools;
    using AtomicTorch.CBND.GameApi.Data.World;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public static class PveZoneDamage
    {

        public static double getTreeDamageMultiplier(IStaticWorldObject worldObj)
        {
            if(PveZone.IsPveZone(worldObj))
            {
                return ToolsConstants.ActionWoodcuttingSpeedMultiplierPvE;
            }

            return ToolsConstants.ActionWoodcuttingSpeedMultiplier;
        }

        public static double getMiningDamageMultiplier(IStaticWorldObject worldObj)
        {
            if (PveZone.IsPveZone(worldObj))
            {
                return ToolsConstants.ActionMiningSpeedMultiplierPvE;
            }

            return ToolsConstants.ActionMiningSpeedMultiplier;
        }

        public static double getServerCraftingSpeedMultiplier(ICharacter character)
        {
            if (PveZone.IsPveZone(character))
            {
                return CraftingSystem.ServerCraftingSpeedMultiplierPve;
            }

            return CraftingSystem.ServerCraftingSpeedMultiplier;
        }

        public static double getClientCraftingSpeedMultiplier(ICharacter character)
        {
            if (PveZone.IsPveZone(character))
            {
                return CraftingSystem.ClientCraftingSpeedMultiplierPve;
            }

            return CraftingSystem.ClientCraftingSpeedMultiplier;
        }
    }
}