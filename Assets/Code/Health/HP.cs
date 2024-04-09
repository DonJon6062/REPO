using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;

    [SerializeField] private AudioClip healSound;
    [SerializeField] private AudioClip[] hurtSound;
    [SerializeField] private AudioClip[] deathSound;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount, Pawn source)
    {
        if (source != null) 
        {
            currentHealth -= amount;
            //Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name);
            SFX_Manager.instance.PlayRandomSoundClip(hurtSound, transform, 1f);

            if (currentHealth <= 0)
            {
                Die(source);
            }
        }

    }

    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        SFX_Manager.instance.PlaySoundClip(healSound, transform, 1f);
    }

    public void Die(Pawn source)
    {
        Destroy(source);
    }
}
