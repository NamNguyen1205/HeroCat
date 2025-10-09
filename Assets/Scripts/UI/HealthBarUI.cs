using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private Slider slider;
    private Entity_Health entityHealth;
    private Entity entity;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        entityHealth = GetComponentInParent<Entity_Health>();
        entity = GetComponentInParent<Entity>();
        
    }

    private void Update()
    {
        slider.value = entityHealth.GetCurrentHealth() / entityHealth.GetMaxHealth();
    }

    private void OnEnable()
    {
        entity.OnFlipping += HandleUIFlip;
    }

    private void OnDisable()
    {
        entity.OnFlipping -= HandleUIFlip;
    }

    private void HandleUIFlip() => transform.rotation = Quaternion.identity;
}
