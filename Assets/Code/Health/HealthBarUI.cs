using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class HealthBarUI : MonoBehaviour
{
    public float currentHealth;
    public float damage;
    public float maxHealth = 100;

    public Image healthPercent;
    public void Start()
    {

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TakeDamage(20);
        }
    }
    public void TakeDamage(float damage) 
    {
        healthPercent.fillAmount = currentHealth / maxHealth;
    }
}
