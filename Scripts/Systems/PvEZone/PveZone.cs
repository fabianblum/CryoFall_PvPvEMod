﻿namespace AtomicTorch.CBND.CoreMod.Systems.PveZone
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
    using AtomicTorch.CBND.GameApi.Data.Items;
    using AtomicTorch.CBND.GameApi.Resources;
    using AtomicTorch.CBND.GameApi.Scripting;
    using AtomicTorch.CBND.GameApi.Scripting.ClientComponents;
    using AtomicTorch.CBND.GameApi.ServicesClient.Components;
    using AtomicTorch.CBND.CoreMod.Systems.Notifications;
    using AtomicTorch.CBND.GameApi.Data.World;
    using AtomicTorch.CBND.CoreMod.Systems.WorldMapResourceMarks;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.GameEngine.Common.Primitives;

    public class PveZone : ProtoSystem<PveZone>
    {
        public override string Name => "PvE Zone system";

        public static readonly bool PveZoneEnabled;

        static PveZone()
        {
            PveZoneEnabled = ServerRates.Get(
                "PvEZone",
                defaultValue: 0,
                @"Defines if the PvE Zone is enabled (1) or disabled (0).")
                != 1;
        }
        public static bool IsPveZone(ICharacter character)
        {
            if(!PveZoneEnabled)
            {
                return false;
            }

            
            var pveArea = ZonePvE.Instance.ServerZoneInstance;
            return pveArea.IsContainsPosition(character.Position.ToVector2Ushort());
        }

        public static bool IsPveZone(Vector2Ushort position)
        {
            
            if (!PveZoneEnabled)
            {
                return false;
            }
            

            if(position.Y < 9879)
            {
                return true;
            }

            return false;

            //var pveArea = ZonePvE.Instance.ServerZoneInstance;
            //return pveArea.IsContainsPosition(position);
        }

        public static bool IsPveZone(IStaticWorldObject worldObj)
        {
            if (!PveZoneEnabled)
            {
                return false;
            }
            
            var pveArea = ZonePvE.Instance.ServerZoneInstance;
            return pveArea.IsContainsPosition(WorldMapResourceMarksSystem.SharedGetObjectCenterPosition(worldObj));
        }
    }
}