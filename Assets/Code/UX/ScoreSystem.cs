using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public UnityEvent onScoreChanged;

    public Text scoreText;
    public static int ScoreCount { get; private set; }

    public void AddScore(int amount) 
    {
        ScoreCount += amount;
        onScoreChanged.Invoke();
    }
}
