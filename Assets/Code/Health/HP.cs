using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public float currentHealth;
    //public float damage;
    public float maxHealth = 100;
    public HealthinessMeter healthinessMeter;
    [SerializeField] private int lives;

    [SerializeField] private AudioClip healSound;
    [SerializeField] private AudioClip[] hurtSound;
    [SerializeField] private AudioClip[] deathSound;

    readonly Respawn respawn;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //healthinessMeter.SetMax(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float amount, Pawn source)
    {
        currentHealth -= amount;
        //healthinessMeter.SetMax(currentHealth);
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
        //healthinessMeter.SetMax(currentHealth);
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
            SceneManager.LoadScene("Game_Over");
        }
        else 
        {
            respawn.RespawnPlayer(source);
        }
    }
}
