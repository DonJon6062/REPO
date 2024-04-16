using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDistributor : MonoBehaviour
{
    [SerializeField] private int killCount;

    private ScoreSystem scoreSystem;


    private void Awake()
    {
        scoreSystem = gameObject.GetComponent<ScoreSystem>();
    }

    public void DistributeScore() 
    {
        scoreSystem.AddScore(killCount);
    }
}
