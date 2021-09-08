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

    public class ItemSuperHeavySuitlvl3 : ItemSuperHeavySuit
    {
        public override uint DurabilityMax => 1600;

        public override string Name => "Super heavy armor LVL 3";

        protected override void PrepareDefense(DefenseDescription defense)
        {
            defense.Set(
                impact: 0.94,
                kinetic: 0.94,
                explosion: 0.94,
                heat: 0.94,
                cold: 0.94,
                chemical: 0.94,
                radiation: 0.44,
                psi: 0.44);
        }
    }
}