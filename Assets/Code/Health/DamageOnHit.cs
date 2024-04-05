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
        HP otherHP = other.gameObject.GetComponent<HP>();
        if (otherHP != null)
        {
            otherHP.TakeDamage(damageDone, owner);
            Debug.Log("Hit!");
        }
        else
        {
            Debug.Log("Null");
        }
        Destroy(gameObject);
    }
}
