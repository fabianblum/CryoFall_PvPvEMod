namespace AtomicTorch.CBND.CoreMod.Systems.PvEZone
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
    using AtomicTorch.CBND.CoreMod.Technologies;
    using AtomicTorch.CBND.CoreMod.Systems.Droplists;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Misc.Events;

    public static class PvEZoneMultiplier
    {

        public static double getTreeDamageMultiplier(IStaticWorldObject worldObj)
        {
            /*if(PvEZone.IsPvEZone(worldObj))
            {
                return ToolsConstants.ActionWoodcuttingSpeedMultiplierPvE;
            }

            return ToolsConstants.ActionWoodcuttingSpeedMultiplier;*/

            return 1;
        }

        public static double getMiningDamageMultiplier(IStaticWorldObject worldObj)
        {
            /*if (PvEZone.IsPvEZone(worldObj))
            {
                return ToolsConstants.ActionMiningSpeedMultiplierPvE;
            }

            return ToolsConstants.ActionMiningSpeedMultiplier;*/
            return 1;
        }

        public static double getServerCraftingSpeedMultiplier(ICharacter character)
        {
            /*if (PvEZone.IsPvEZone(character))
            {
                return CraftingSystem.ServerCraftingSpeedMultiplierPve;
            }

            return CraftingSystem.ServerCraftingSpeedMultiplier;*/

            return 1;
        }

        public static double getClientCraftingSpeedMultiplier(ICharacter character)
        {
            /*if (PvEZone.IsPvEZone(character))
            {
                return CraftingSystem.ClientCraftingSpeedMultiplierPve;
            }

            return CraftingSystem.ClientCraftingSpeedMultiplier;*/

            return 1;
        }

        public static double getExperienceGainMultiplier(ICharacter character)
        {
            /*if (PvEZone.IsPvEZone(character))
            {
                return TechConstants.ServerSkillExperienceGainMultiplierPvE;
            }

            return TechConstants.ServerSkillExperienceGainMultiplier;*/

            return 1;
        }

        public static double getLearningPointsGainMultiplier(ICharacter character)
        {
            /*if (PvEZone.IsPvEZone(character))
            {
                return TechConstants.ServerLearningPointsGainMultiplierPvE;
            }

            return TechConstants.ServerLearningPointsGainMultiplier;*/

            return 1;
        }

        public static double getDropListItemCountMultiplier(ICharacter character)
        {
            /*
            if (PvEZone.IsPvEZone(character))
            {
                return DropItemsList.DropListItemsCountMultiplierPvE;
            }

            return DropItemsList.DropListItemsCountMultiplier;*/

            return 1;
        }

        public static double getDropListItemCountMultiplier(IStaticWorldObject worldObj)
        {
            /*if (PvEZone.IsPvEZone(worldObj))
            {
                return DropItemsList.DropListItemsCountMultiplierPvE;
            }

            return DropItemsList.DropListItemsCountMultiplier;*/

            return 1;
        }

        public static double getLootCountMultiplier(IStaticWorldObject worldObj, double defaultMultiplier, double pvEMultiplier)
        {
            if (PvEZone.IsPvEZone(worldObj))
            {
                return pvEMultiplier;
            }

            return defaultMultiplier;
        }
    }
}