using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDistributor : MonoBehaviour
{
    public int killCount;

    public ScoreSystem scoreSystem;

    private void Awake()
    {
        scoreSystem = GetComponent<ScoreSystem>();
    }

    public void DistributeScore() 
    {
        scoreSystem.AddScore(killCount);
    }
}
