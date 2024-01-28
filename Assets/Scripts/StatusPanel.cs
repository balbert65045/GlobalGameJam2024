using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatusPanel : MonoBehaviour
{
    [SerializeField] GameObject LosePanel;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject ScorePanel;
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] TMP_Text HighScoreText;
    [SerializeField] GameObject StartText;

    float StartTextTime = 2f;
    bool startTextAvailable = true;
    bool lost = false;
    bool won = false;

    public bool LostOrWon() { return lost || won; }
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

    public void HideGo()
    {
        StartText.SetActive(false);
    }

    public void Win()
    {
        won = true;
        Time.timeScale = 0;
        WinPanel.SetActive(true);
        AttemptToSaveScore();
        ShowScores();
    }

    public void Lose()
    {
        lost = true;
        LosePanel.SetActive(true);
        AttemptToSaveScore();
        ShowScores();
    }

    void ShowScores()
    {
        ScorePanel.SetActive(true);
        ScoreText.text = Mathf.RoundToInt(FindObjectOfType<Score>().score).ToString();
        HighScoreText.text = SaveSystem.LoadPlayer().scorePerLevel[SceneManager.GetActiveScene().buildIndex - 1].ToString();
    }

    void AttemptToSaveScore()
    {
        int score = Mathf.RoundToInt(FindObjectOfType<Score>().score);
        FindObjectOfType<PlayerTracker>().SaveNewLevelStatus(SceneManager.GetActiveScene().buildIndex - 1, score);
    }
}
