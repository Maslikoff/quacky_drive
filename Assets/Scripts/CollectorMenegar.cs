using UnityEngine;

public class CollectorMenegar : MonoBehaviour
{
    [SerializeField] private GameObject _collectorPrefab; 
    [SerializeField] private Transform[] _spawnPoints; 
    [SerializeField] private int _totalCollectors = 10; 

    private LevelManager _levelManager;
    private int _carsDestroyed = 0; 

    private void Start()
    {
        SpawnCar();
    }

    public void OnCarDestroyed()
    {
        _carsDestroyed++;
        SpawnCar(); 
    }

    private void SpawnCar()
    {
        if (_carsDestroyed < _totalCollectors)
        {
            int randomIndex = Random.Range(0, _spawnPoints.Length);
            Transform spawnPoint = _spawnPoints[randomIndex];

            GameObject car = Instantiate(_collectorPrefab, spawnPoint.position, spawnPoint.rotation);
            car.AddComponent<Collector>().SetSpawner(this);
        }
        else
        {
            LoadVictoryScene();
        }
    }

    private void LoadVictoryScene()
    {
        _levelManager.LoadVictoryScene();
    }
}
