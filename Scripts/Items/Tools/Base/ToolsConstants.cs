namespace AtomicTorch.CBND.CoreMod.Items.Tools
{
    using System.Runtime.CompilerServices;

    public class ToolsConstants
    {
        public static readonly double ActionMiningSpeedMultiplier;

        public static readonly double ActionMiningSpeedMultiplierPvE;

        public static readonly double ActionWoodcuttingSpeedMultiplier;

        public static readonly double ActionWoodcuttingSpeedMultiplierPvE;

        static ToolsConstants()
        {
            ActionMiningSpeedMultiplier = ServerRates.Get(
                "ActionMiningSpeedMultiplier",
                defaultValue: 1.0,
                @"Adjusts the damage to minerals by mining tools.");

            ActionWoodcuttingSpeedMultiplier = ServerRates.Get(
                "ActionWoodcuttingSpeedMultiplier",
                defaultValue: 1.0,
                @"Adjusts the damage to trees by woodcutting tools.");

            ActionMiningSpeedMultiplierPvE = ServerRates.Get(
                "ActionMiningSpeedMultiplierPvE",
                defaultValue: 1.0,
                @"Adjusts the damage to minerals by mining tools in the PvE Zone.");

            ActionWoodcuttingSpeedMultiplierPvE = ServerRates.Get(
                "ActionWoodcuttingSpeedMultiplierPvE",
                defaultValue: 1.0,
                @"Adjusts the damage to trees by woodcutting tools in the PvE Zone.");
        }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public static void EnsureInitialized()
        {
        }
    }
}