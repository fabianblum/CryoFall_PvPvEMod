
      string mobCountString = ServerRates.Get(
      "MigrationMutantMobCount",
      defaultValue: "1,4,8,13,20",
      @"Number of mobs for each claims (T1 to T5).");

      string[] mobCountSplit = mobCountString.Replace(" ", "").Split(',');
      if (mobCountSplit.Length != 5)
        MigrationMutantMobCount = new int[] { 1, 4, 5, 13, 20 };
      else
        MigrationMutantMobCount = Array.ConvertAll(mobCountSplit, s => int.Parse(s));

      for (int i = 0; i < MigrationMutantMobCount.Length; i++)
        MigrationMutantMobCount[i] = MathHelper.Clamp(MigrationMutantMobCount[i], 0, 50);


     string mobMaxLevelString = ServerRates.Get(
     "MigrationMutantMobMaxLevelPerWave",
     defaultValue: "1,2,3,4,5",
     @"Max level of mobs for each wave.");

      string[] mobMaxLevelSplit = mobMaxLevelString.Replace(" ", "").Split(',');
      if (mobMaxLevelSplit.Length != MigrationMutantWaveCount)
        MigrationMutantMobMaxLevelPerWave = new int[] { 1, 2, 3, 4, 5 };
      else
        MigrationMutantMobMaxLevelPerWave = Array.ConvertAll(mobMaxLevelSplit, s => int.Parse(s));

      for (int i = 0; i < MigrationMutantMobMaxLevelPerWave.Length; i++)
        MigrationMutantMobMaxLevelPerWave[i] = MathHelper.Clamp(MigrationMutantMobMaxLevelPerWave[i], 1, 5);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void EnsureInitialized()
    {
    }
  }
}