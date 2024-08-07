using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suitcase : MonoBehaviour
{
    private SuitcaseManager _suitcaseManager;

    private void Start()
    {
        _suitcaseManager = FindObjectOfType<SuitcaseManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            _suitcaseManager.OnSuitcasePickedUp();
            Destroy(gameObject);
        }
    }
}
