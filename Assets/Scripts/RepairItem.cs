using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairItem : MonoBehaviour
{
    [SerializeField] private float healthToRestore = 250f;

    private void Update()
    {
        transform.Rotate(Vector3.up, 50 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) 
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                float currentHealth = playerHealth.GetHealth();
                float maxHealth = playerHealth.GetMaxHealth();

                if (currentHealth < maxHealth)
                {
                    float healthDiff = maxHealth - currentHealth;
                    if (healthToRestore > healthDiff)
                    {
                        playerHealth.ApplyHealing(healthDiff);
                    }
                    else
                    {
                        playerHealth.ApplyHealing(healthToRestore);
                    }

                    Destroy(gameObject); 
                }
            }
        }
    }
}
