using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    //on player 
    public int ScoreCount { get; private set; }

    public UnityEvent onScoreChanged;

    public void AddScore(int amount) 
    {
        ScoreCount += amount;
        onScoreChanged.Invoke();
    }
}
