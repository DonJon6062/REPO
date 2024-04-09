using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damageDone;
    public Pawn owner;
    
    public void OnTriggerEnter(Collider other)
    {
        //get health component
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        HP otherHP = other.gameObject.GetComponent<HP>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageDone, owner);
            Debug.Log("Hit!");
        }

        if (otherHP != null)
        {
            otherHP.TakeDamage(damageDone, owner);
        }
        Destroy(gameObject);
    }
}
