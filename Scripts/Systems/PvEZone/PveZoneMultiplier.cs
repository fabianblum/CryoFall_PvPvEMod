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
    using AtomicTorch.CBND.CoreMod.Rates;

    public static class PvEZoneMultiplier
    {

        public static double getTreeDamageMultiplier(IStaticWorldObject worldObj)
        {
            if(PvEZone.IsPvEZone(worldObj))
            {
                return RateActionWoodcuttingSpeedMultiplierPvE.SharedValue;
            }

            return RateActionWoodcuttingSpeedMultiplier.SharedValue;
        }

        public static double getMiningDamageMultiplier(IStaticWorldObject worldObj)
        {
            if (PvEZone.IsPvEZone(worldObj))
            {
                return RateActionMiningSpeedMultiplierPvE.SharedValue;
            }

            return RateActionMiningSpeedMultiplier.SharedValue;
        }

        public static double getCraftingSpeedMultiplier(ICharacter character)
        {
            if (PvEZone.IsPvEZone(character))
            {
                return RateCraftingSpeedMultiplierPvE.SharedValue;
            }

            return RateCraftingSpeedMultiplier.SharedValue;
        }

        public static double getManufacturingSpeedMultiplier(IStaticWorldObject worldObj)
        {
            if (PvEZone.IsPvEZone(worldObj))
            {
                return RateManufacturingSpeedMultiplierPvE.SharedValue;
            }

            return RateManufacturingSpeedMultiplier.SharedValue;
        }

        public static double getExtractorMultiplier(IStaticWorldObject worldObj)
        {
            if (PvEZone.IsPvEZone(worldObj))
            {
                return RateDepositsExtractionSpeedMultiplierPvE.SharedValue;
            }

            return RateDepositsExtractionSpeedMultiplier.SharedValue;
        }

        public static double getExperienceGainMultiplier(ICharacter character)
        {
            if (PvEZone.IsPvEZone(character))
            {
                return RateSkillExperienceGainMultiplierPvE.SharedValue;
            }

            return RateSkillExperienceGainMultiplier.SharedValue;
        }

        public static double getLearningPointsGainMultiplier(ICharacter character)
        {
            if (PvEZone.IsPvEZone(character))
            {
                return RateLearningPointsGainMultiplierPvE.SharedValue;
            }

            return RateLearningPointsGainMultiplier.SharedValue;
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

        public static int getMutantMigrationMobCount(ushort level, IStaticWorldObject worldObj)
        {
            if (PvEZone.IsPvEZone(worldObj))
            {
                return RateMigrationMutantMobCountPvE.SharedValues[level];
            }

            return RateMigrationMutantMobCount.SharedValues[level];
        }

        public static int getMutantMigrationmaxLevelPerWave(byte waveNumber, IStaticWorldObject worldObj)
        {
            if (PvEZone.IsPvEZone(worldObj))
            {
                return RateMigrationMutantMobCountPvE.SharedValues[waveNumber];
            }

            return RateMigrationMutantMobCount.SharedValues[waveNumber];
        }
    }
}