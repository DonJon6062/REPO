using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text totalScore;

    private void Awake()
    {
        totalScore = GetComponent<TMP_Text>();
        totalScore.text = $"Score: 0";
    }
    public void UpdateScore(ScoreSystem scoreSystem)
    {
        totalScore.text = $"Score: {scoreSystem.ScoreCount}";
    }
}
