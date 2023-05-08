using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ProgressionManager
{
    private static bool[] levelsUnlocked = new bool[3];

    public static void UnlockLevel(int levelNumber)
    {
        if (levelNumber <= levelsUnlocked.Length)
        {
            levelsUnlocked[levelNumber - 1] = true;
        }
        else
        {
            Debug.LogWarning($"Level {levelNumber} does not exist.");
        }
    }

    public static bool IsLevelUnlocked(int levelNumber)
    {
        if (levelNumber <= levelsUnlocked.Length)
        {
            if (levelNumber == 0)
            {
                return false;
            }
            else
            {
                return levelsUnlocked[levelNumber - 1];
            }
        }
        else
        {
            Debug.LogWarning($"Level {levelNumber} does not exist.");
            return false;
        }
    }
}