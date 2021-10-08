﻿namespace AtomicTorch.CBND.CoreMod.Vehicles
{
  using System.ComponentModel;

  public enum VehicleWeaponHardpoint : byte
  {
    [Description("Normal")]
    Normal,

    [Description("Large")]
    Large,

    [Description("Tool")]
    Tool,

    [Description("Exotic")]
    Exotic
    }
}