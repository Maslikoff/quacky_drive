using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float damageAmount = 20f; 

    private CollectorMenegar _spawner;

    public void SetSpawner(CollectorMenegar spawner)
    {
        this._spawner = spawner;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            health -= damageAmount;
            Debug.Log($"Здоровье коллектора: {health}");

            if (health <= 0)
            {
                DestroyCar();
            }
        }
    }

    private void DestroyCar()
    {
        _spawner.OnCarDestroyed();
        Destroy(gameObject);
    }
}
