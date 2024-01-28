using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text streakText;
    [SerializeField] float amountToChangeScoreBy = 50f;
    float score = 0;
    int streak = 0;
    float streakMultiplier = 10f;
    void Start()
    {
        InputArea[] inputAreas = FindObjectsOfType<InputArea>();
        foreach (InputArea area in inputAreas)
        {
            area.OnBadInput += DecreaseScore;
            area.OnGoodInput += IncreaseScore;
            area.OnHoldInput += HoldIncreaseScore;
        }
    }

    void HoldIncreaseScore()
    {
        score += 1 + streak;
        scoreText.text = score.ToString();
    }

    void IncreaseScore()
    {
        score += amountToChangeScoreBy + streak*streakMultiplier;
        streak++;
        streak = Mathf.Clamp(streak, 0, 8);
        if (streak > 1)
        {
            streakText.gameObject.SetActive(true);
            streakText.text = "x" + streak.ToString();
        }
        scoreText.text = score.ToString();
    }

    void DecreaseScore()
    {
        streak = 0;
        streakText.gameObject.SetActive(false);
        score -= amountToChangeScoreBy;
        scoreText.text = score.ToString();
    }
}
