using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreDistributor : MonoBehaviour
{
    [SerializeField] private int scoreAmount;
    public void AddScore(Collider other, Pawn source)
    {
        Debug.Log("AddScore!");
        Debug.Log(source.name + " killed you!");

        ScoreUI scoreUI = FindAnyObjectByType<ScoreUI>();
        ScoreUI_2 scoreUI_2 = FindAnyObjectByType<ScoreUI_2>();

        ScoreSystem scoreSystem = source.gameObject.GetComponent<ScoreSystem>();

        if (scoreSystem != null)
        {
            scoreSystem.AddScore(scoreAmount);
            scoreUI.UpdateScore(scoreSystem);

            Debug.Log("Added to P1!");
        }

        ScoreManager scoreManager = source.gameObject.GetComponent<ScoreManager>();

        if (scoreManager != null)
        {
            scoreManager.AddScore(scoreAmount);
            scoreUI_2.UpdateScoreP2(scoreManager);

            Debug.Log("Added to P2!");
        }
    }
}
