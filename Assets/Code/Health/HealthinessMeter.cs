using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthinessMeter : MonoBehaviour
{
    public Slider healthPercent;
    [SerializeField] private Camera cameraForHP;
    [SerializeField] private Transform transformForHP;
    private Vector3 offset;
    public void SetMax(float health)
    {
        healthPercent.maxValue = health;
        healthPercent.value = health;
    }
    public void SetHealth(float health)
    {
        healthPercent.value = health;
    }

    public void Start()
    {
        cameraForHP = GetComponent<Camera>();
    }

    public void Update()
    {
        transformForHP.rotation = cameraForHP.transform.rotation;
        transform.position = transformForHP.position + offset;
    }
}
