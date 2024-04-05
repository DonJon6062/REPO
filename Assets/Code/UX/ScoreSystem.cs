using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public UnityEvent onScoreChanged;

    public TMP_Text scoreText;
    public static int ScoreCount { get; private set; }

    public void AddScore(int amount) 
    {
        ScoreCount += amount;
    }
}
