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
    }
    public void UpdateScore(int amount)
    {
        totalScore.text = $"Score: {amount}";
    }
}
