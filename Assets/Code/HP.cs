using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float currentHealth;
    public float damage;
    public float maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage (float amount, Pawn source)
    {
        currentHealth -= amount;
        Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name);
        
        if (currentHealth <= 0) 
        {
            Die(source);
        }
    }

    public void RestoreHealth (float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void Die (Pawn source) 
    {
        Destroy(gameObject);
        Debug.Log(source.name + " destroyed " + gameObject.name);
    }
}
