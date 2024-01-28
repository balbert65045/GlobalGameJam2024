using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public int[] scorePerLevel;

    [SerializeField] bool OverwriteSaveFile;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType<PlayerTracker>().Length > 1)
        {
            Destroy(FindObjectsOfType<PlayerTracker>()[1].gameObject);
        }
        if (SaveSystem.PlayerHasData() && !OverwriteSaveFile)
        {
            PlayerSavedData data = SaveSystem.LoadPlayer();
            scorePerLevel = data.scorePerLevel;
        }
        else
        {
            SaveData();
        }
    }

    public void SaveNewLevelStatus(int level, int score)
    {
        if (score > scorePerLevel[level])
        {
            scorePerLevel[level] = score;
            SaveData();
        }
    }

    public void SaveData()
    {
        SaveSystem.SavePlayer(this);
    }
}
