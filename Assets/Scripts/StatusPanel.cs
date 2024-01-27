using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPanel : MonoBehaviour
{
    [SerializeField] GameObject LosePanel;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject StartText;

    float StartTextTime = 2f;
    bool startTextAvailable = true;
    void Start()
    {
        StatusBar status = FindObjectOfType<StatusBar>();
        status.OnLose += Lose;
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.OnWin += Win;
    }

    public void ShowGo()
    {
        StartText.SetActive(true);
    }
    private void Update()
    {
        if (Time.timeSinceLevelLoad > StartTextTime && startTextAvailable)
        {
            startTextAvailable = false;
            StartText.SetActive(false);
        }
    }

    public void Win()
    {
        Time.timeScale = 0;
        WinPanel.SetActive(true);
    }

    public void Lose()
    {
        Time.timeScale = 0;
        LosePanel.SetActive(true);
    }
}
