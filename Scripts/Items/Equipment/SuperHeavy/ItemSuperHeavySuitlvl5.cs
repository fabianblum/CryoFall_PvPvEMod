namespace AtomicTorch.CBND.CoreMod.Items.Equipment.SuperHeavyArmor
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.Characters;
    using AtomicTorch.CBND.CoreMod.Characters.Player;
    using AtomicTorch.CBND.CoreMod.ClientComponents.Input;
    using AtomicTorch.CBND.CoreMod.ClientComponents.PostEffects.NightVision;
    using AtomicTorch.CBND.CoreMod.SoundPresets;
    using AtomicTorch.CBND.CoreMod.Stats;
    using AtomicTorch.CBND.CoreMod.Systems.TimeOfDaySystem;
    using AtomicTorch.CBND.CoreMod.UI.Controls.Menu.Options.Data;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Data.Items;
    using AtomicTorch.CBND.GameApi.Data.State;
    using AtomicTorch.CBND.GameApi.Scripting;
    using AtomicTorch.CBND.GameApi.Scripting.ClientComponents;
    using AtomicTorch.CBND.GameApi.ServicesClient.Components;

    public class ItemSuperHeavySuitlvl5 : ItemSuperHeavySuit
    {
        public override uint DurabilityMax => 1750;

        public override string Name => "Super heavy armor LVL 5";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 1.00,
                kinetic: 1.00,
                explosion: 1.00,
                heat: 1.00,
                cold: 1.00,
                chemical: 1.00,
                radiation: 0.5,
                psi: 0.5);
        }
    }
}