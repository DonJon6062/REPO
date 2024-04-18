using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    
    public HealthinessMeter healthinessMeter;
    
    [SerializeField] private int lives;

    [SerializeField] private AudioClip healSound;
    [SerializeField] private AudioClip[] hurtSound;
    [SerializeField] private AudioClip[] deathSound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthinessMeter = GetComponentInChildren<HealthinessMeter>();
        healthinessMeter.SetMax(maxHealth);
    }

    public void TakeDamage(float amount, Pawn source)
    {
        currentHealth -= amount;
        healthinessMeter.SetHealth(currentHealth);
        //Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name);
        SFX_Manager.instance.PlayRandomSoundClip(hurtSound, transform, 1f);

        if (currentHealth <= 0)
        {
            WasKilled(source);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            TakeDamage(20, source);
            Debug.Log("Owie");
        }
    }

    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        healthinessMeter.SetHealth(currentHealth);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        SFX_Manager.instance.PlaySoundClip(healSound, transform, 1f);
    }

    public void WasKilled(Pawn source)
    {
        //Debug.Log(source.name + " destroyed " + gameObject.name);
        SFX_Manager.instance.PlayRandomSoundClip(deathSound, transform, 1f);
        lives -= 1;
        if (lives <= 0)
        {
            GameManager.instance.ActivateGameOverState();
            maxHealth = 100;
            currentHealth = maxHealth;
            healthinessMeter.SetMax(maxHealth);
            lives = 3;
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
