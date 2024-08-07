using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car") || 
            collision.gameObject.CompareTag("Police") || 
            collision.gameObject.CompareTag("Collector"))
        {
            Collider collider = GetComponent<Collider>();
            collider.isTrigger = true;

            Destroy(gameObject, 3f);
        }
    }
}
