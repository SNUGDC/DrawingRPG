using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    private const string LastClearedStageString = "LastClearedStage";
    public static void SaveLastClearedStage(int stage)
    {
        PlayerPrefs.SetInt(LastClearedStageString, stage);
    }

    public static int LoadLastClearedStage()
    {
        int defaultStage = 0;
        return PlayerPrefs.GetInt(LastClearedStageString, defaultStage);
    }

    public static void ResetSave()
    {
		PlayerPrefs.DeleteKey(LastClearedStageString);
    }

	public static void ClearAllStage()
	{
		PlayerPrefs.SetInt(LastClearedStageString, 99);
	}
}
