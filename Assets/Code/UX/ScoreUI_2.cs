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
    }

    public void UpdateScoreP2(int amount)
    {
        playerTwoTotalScore.text = $"Score: {amount}";
    }
}
