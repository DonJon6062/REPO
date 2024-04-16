using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TMP_Text scoreText;
    public static int ScoreCount { get; private set; }

    public UnityEvent onScoreChanged;

    public void AddScore(int amount) 
    {
        ScoreCount += amount;
        onScoreChanged.Invoke();
    }
}
