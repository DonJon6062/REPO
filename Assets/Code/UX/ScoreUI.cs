using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text totalScore;

    void Awake()
    {
        totalScore = GetComponent<TMP_Text>();
    }

    public void UpdateScore(ScoreSystem scoreSystem)
    {
        totalScore.text = $"Score: {scoreSystem.scoreText}";
    }
}
