﻿namespace AtomicTorch.CBND.CoreMod.Systems.Construction
{
    using System;
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.Characters.Player;
    using AtomicTorch.CBND.CoreMod.Systems.Creative;
    using AtomicTorch.CBND.CoreMod.Systems.Notifications;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Items;
    using AtomicTorch.CBND.GameApi.Scripting;

    public class ConstructionStageConfig : IConstructionStageConfigReadOnly
    {
        private readonly InputItems stageRequiredItems;

        private byte stagesCount = 5;

        private double stageDurationSeconds = 1;

        public ConstructionStageConfig()
        {
            this.stageRequiredItems = new InputItems();
            this.StageRequiredItems = this.stageRequiredItems.AsReadOnly();
        }

        public bool IsAllowed { get; set; } = true;

        public double StageDurationSeconds {
            get => this.stageDurationSeconds * 0.25;
            set
            {
                this.stageDurationSeconds = value;
            } 
        }

        public IReadOnlyList<ProtoItemWithCount> StageRequiredItems { get; }

        public byte StagesCount
        {
            get => this.stagesCount;
            set
            {
                if (value == 0)
                {
                    throw new Exception("There are must be at least 1 stage.");
                }

                this.stagesCount = value;
            }
        }

        public void AddStageRequiredItem<TProtoItem>(ushort count = 1)
            where TProtoItem : class, IProtoItem, new()
        {
            this.stageRequiredItems.Add<TProtoItem>(count);
        }

        public void ApplyRates(byte multiplier)
        {
            this.stageRequiredItems.ApplyRates(multiplier);
        }

        public bool CheckStageCanBeBuilt(ICharacter character)
        {
            if (!this.IsAllowed)
            {
                // not allowed to be built/repaired
                return false;
            }

            if (character is null)
            {
                return true;
            }

            if (CreativeModeSystem.SharedIsInCreativeMode(character))
            {
                return true;
            }

            foreach (var requiredItem in this.StageRequiredItems)
            {
                if (!character.ContainsItemsOfType(requiredItem.ProtoItem, requiredItem.Count))
                {
                    // some item is not available
                    return false;
                }
            }

            // all required items are available
            return true;
        }

        public void ServerDestroyRequiredItems(ICharacter character)
        {
            if (CreativeModeSystem.SharedIsInCreativeMode(character))
            {
                Api.Logger.Important(character + " is in creative mode - no items deduction on construction.");
                return;
            }

            // assume all the validation has been done before this action
            var requiredItems = this.StageRequiredItems;
            InputItemsHelper.ServerDestroyItems(character, requiredItems);
        }

        public void ServerReturnRequiredItems(ICharacter character, byte stagesCount = 1)
        {
            Api.Assert(stagesCount >= 1, "Stages count should be at least 1");

            var itemsChangedCount = new Dictionary<IProtoItem, int>();

            IItemsContainer groundItemsContainer = null;
            foreach (var requiredItem in this.StageRequiredItems)
            {
                var countToReturn = requiredItem.Count * stagesCount;
                PlayerCharacter.ServerTrySpawnItemToCharacterOrGround(character,
                                                                      requiredItem.ProtoItem,
                                                                      (uint)countToReturn,
                                                                      ref groundItemsContainer);

                // TODO: it would be better if we use the actual item spawn result here
                itemsChangedCount[requiredItem.ProtoItem] = countToReturn;
            }

            NotificationSystem.ServerSendItemsNotification(character, itemsChangedCount);

            if (groundItemsContainer is not null)
            {
                // spawned something on the ground
                NotificationSystem.ServerSendNotificationNoSpaceInInventory(character);
            }
        }
    }
}