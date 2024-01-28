using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSavedData
{
    public int[] scorePerLevel;
    public PlayerSavedData(PlayerTracker playerTracker)
    {
        scorePerLevel = playerTracker.scorePerLevel;
    }
}
