using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public int GetMaxHealth()
    {
        return (int)slider.maxValue;
    }

    public int GetCurrentHealth()
    {
        return (int)slider.value;
    }

    public void IncreaseHealth(int amount)
    {
        int newHealth = (int)slider.value + amount;
        if (newHealth > slider.maxValue)
        {
            slider.value = slider.maxValue;
        }
        else
        {
            slider.value = newHealth;
        }
    }

    public void DecreaseHealth(int amount)
    {
        int newHealth = (int)slider.value - amount;
        if (newHealth < 0)
        {
            slider.value = 0;
        }
        else
        {
            slider.value = newHealth;
        }
    }
}
