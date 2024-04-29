using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI_2 : MonoBehaviour
{
    public TMP_Text playerTwoTotalScore;

    private void Awake()
    {
        playerTwoTotalScore = GetComponent<TMP_Text>();
        playerTwoTotalScore.text = $"Score: 0";
    }

    public void UpdateScoreP2(ScoreManager scoreManager)
    {
        playerTwoTotalScore.text = $"Score: {scoreManager.ScoreCount}";
    }
}
