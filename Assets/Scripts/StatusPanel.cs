using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusPanel : MonoBehaviour
{
    [SerializeField] GameObject LosePanel;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject StartText;

    float StartTextTime = 2f;
    bool startTextAvailable = true;
    bool lost = false;
    void Start()
    {
        StatusBar status = FindObjectOfType<StatusBar>();
        status.OnLose += Lose;
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.OnWin += Win;
    }
    public void Show3()
    {
        StartText.SetActive(true);
        StartText.GetComponent<TMP_Text>().text = "3";
    }

    public void Show2()
    {
        StartText.GetComponent<TMP_Text>().text = "2";
    }

    public void Show1()
    {
        StartText.GetComponent<TMP_Text>().text = "1";
    }
    public void ShowGo()
    {
        StartText.GetComponent<TMP_Text>().text = "go!";
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
        LosePanel.SetActive(true);
    }
}
