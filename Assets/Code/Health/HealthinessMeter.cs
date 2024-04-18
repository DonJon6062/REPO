using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthinessMeter : MonoBehaviour
{
    public Slider healthPercent;
    public void SetMax(float health)
    {
        healthPercent.maxValue = health;
        healthPercent.value = health;
    }
    public void SetHealth(float health)
    {
        healthPercent.value = health;
    }
}
