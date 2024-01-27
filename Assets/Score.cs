using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
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
        }
    }

    void IncreaseScore()
    {
        score += amountToChangeScoreBy + streak*streakMultiplier;
        streak++;
        scoreText.text = score.ToString();
    }

    void DecreaseScore()
    {
        streak = 0;
        score -= amountToChangeScoreBy;
        scoreText.text = score.ToString();
    }
}
