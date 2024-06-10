using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float HealthCar = 1000f;
    [SerializeField] private float baseDamage = 10f;
    [SerializeField] private float noRigidbodyMultiplier = 2f;

    private HealthBar healthBar;

    private void Start()
    {
        healthBar = GetComponent<HealthBar>();
        if (healthBar != null)
        {
            healthBar.SetMaxHealth((int)HealthCar);
            healthBar.SetHealth((int)HealthCar);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        float damage = baseDamage;

        if (!collision.gameObject.CompareTag("Police"))
        {
            if (collision.gameObject.GetComponent<Rigidbody>() == null)
            {
                damage *= noRigidbodyMultiplier;
            }
            else
            {
                Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                float mass = otherRigidbody.mass;
                damage *= mass / 100;
            }

            ApplyDamage(damage);
        }
    }

    public void ApplyDamage(float damage)
    {
        HealthCar -= damage;
        Debug.Log("Здоровье машины: " + HealthCar);

        if (healthBar != null)
        {
            healthBar.SetHealth((int)HealthCar);
        }

        if (HealthCar <= 0)
        {
            SceneManager.LoadScene("LostScene");
            Debug.Log("Машина разрушена!");
        }
    }

    public void ApplyHealing(float healing)
    {
        HealthCar += healing;
        if (HealthCar > healthBar.GetMaxHealth())
        {
            HealthCar = healthBar.GetMaxHealth();
        }

        if (healthBar != null)
        {
            healthBar.SetHealth((int)HealthCar);
        }
    }

    public float GetHealth()
    {
        return HealthCar;
    }

    public float GetMaxHealth()
    {
        if (healthBar != null)
        {
            return healthBar.GetMaxHealth();
        }

        return 0;
    }
}
