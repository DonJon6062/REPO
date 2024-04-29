using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using static Unity.VisualScripting.Member;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    
    public HealthinessMeter healthinessMeter;
    public LivesToText livesToText;
    
    public int lives = 3;

    [SerializeField] private AudioClip healSound;
    [SerializeField] private AudioClip[] hurtSound;
    [SerializeField] private AudioClip[] deathSound;

    void Start()
    {
        currentHealth = maxHealth;
        
        healthinessMeter = GetComponentInChildren<HealthinessMeter>();
        healthinessMeter.SetMax(maxHealth);

        livesToText = GetComponentInChildren<LivesToText>();
        livesToText.LivesText(lives);
    }

    private void Update()
    {
        GameObject[] Tanks = GameObject.FindGameObjectsWithTag("PlayerTank");
        GameObject[] AITanks = GameObject.FindGameObjectsWithTag("TankPawn");
        
        if (AITanks.Length! < 1 && Tanks.Length <= 1)
        {
            GameManager.instance.ActivateWinScreenState();
            maxHealth = 100;
            currentHealth = maxHealth;
            healthinessMeter.SetMax(maxHealth);
            lives = 3;
            livesToText.LivesText(lives);
        }
    }
    public void TakeDamage(float amount, Pawn source, Collider other)
    {
        currentHealth -= amount;
        healthinessMeter.SetHealth(currentHealth);
        SFX_Manager.instance.PlayRandomSoundClip(hurtSound, transform, 1f);

        if (currentHealth <= 0)
        {
            WasKilled(source, other);
        }
    }

    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        healthinessMeter.SetHealth(currentHealth);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        SFX_Manager.instance.PlaySoundClip(healSound, transform, 1f);
    }

    public void WasKilled(Pawn source, Collider other)
    {
        SFX_Manager.instance.PlayRandomSoundClip(deathSound, transform, 1f);
        lives -= 1;
        livesToText.LivesText(lives);

        ScoreDistributor scoreDistributor = GetComponent<ScoreDistributor>();
        scoreDistributor.AddScore(other, source);

        GameObject[] Tanks = GameObject.FindGameObjectsWithTag("PlayerTank");

        if (lives <= 0)
        {
            if (Tanks.Length > 1)
            {
                BegonePawn begonePawn = GetComponent<BegonePawn>();
                begonePawn.GoAwayPawn();
                
                maxHealth = 100;
                currentHealth = maxHealth;
                healthinessMeter.SetMax(maxHealth);
                lives = 3;
                livesToText.LivesText(lives);
            }
            else
            {
                GameManager.instance.ActivateGameOverState();
                maxHealth = 100;
                currentHealth = maxHealth;
                healthinessMeter.SetMax(maxHealth);
                lives = 3;
                livesToText.LivesText(lives);
            }
        }
        else
        {
            Respawn respawn = GetComponent<Respawn>();
            respawn.RespawnPlayer();
            currentHealth = maxHealth;
            healthinessMeter.SetMax(maxHealth);
        }
    }
}
