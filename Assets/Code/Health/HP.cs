using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HP : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;

    public HealthinessMeter healthinessMeter;

    [SerializeField] private AudioClip healSound;
    [SerializeField] private AudioClip[] hurtSound;
    [SerializeField] private AudioClip[] deathSound;

    void Start()
    {
        currentHealth = maxHealth;
        healthinessMeter = GetComponentInChildren<HealthinessMeter>();
        healthinessMeter.SetMax(maxHealth);
    }

    public void TakeDamage(float amount, Pawn source, Collider other)
    {
        if (source != null) 
        {
            currentHealth -= amount;
            healthinessMeter.SetHealth(currentHealth);
            SFX_Manager.instance.PlayRandomSoundClip(hurtSound, transform, 1f);

            if (currentHealth <= 0)
            {
                Die(source, other);
            }
        }

    }

    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        healthinessMeter.SetHealth(currentHealth);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        SFX_Manager.instance.PlaySoundClip(healSound, transform, 1f);
    }

    public void Die(Pawn source, Collider other)
    {
        ScoreDistributor scoreDistributor = GetComponent<ScoreDistributor>();
        scoreDistributor.AddScore(other, source);

        GameObject[] Tanks = GameObject.FindGameObjectsWithTag("PlayerTank");
        GameObject[] AITanks = GameObject.FindGameObjectsWithTag("TankPawn");
        
        if (Tanks.Length !< 1)
        {
            GameManager.instance.ActivateGameOverState();
        }
        
        if (AITanks.Length !< 1 && Tanks.Length <= 1)
        {
            GameManager.instance.ActivateWinScreenState();
        }
        
        BegonePawn begonePawn = GetComponent<BegonePawn>();
        begonePawn.GoAwayPawn();
        
        maxHealth = 100;
        currentHealth = maxHealth;
        healthinessMeter.SetMax(maxHealth);
    }
}
