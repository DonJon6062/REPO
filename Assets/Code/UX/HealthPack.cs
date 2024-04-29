using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class HealthPack : MonoBehaviour
{
    public float healAmount;
    public void OnTriggerEnter(Collider other)
    {
        //get health component
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        HP otherHP = other.gameObject.GetComponent<HP>();

        if (playerHealth != null)
        {
            playerHealth.RestoreHealth(healAmount);
        }

        if (otherHP != null)
        {
            otherHP.RestoreHealth(healAmount);
        }
        Destroy(gameObject);
    }
}
