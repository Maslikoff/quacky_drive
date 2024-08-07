using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseManager : MonoBehaviour
{
    [SerializeField] private GameObject _suitcasePrefab; 
    [SerializeField] private Transform[] _spawnSuitcasePoints; 
    [SerializeField] private Transform[] _spawnTargetPoints;
    [SerializeField] private GameObject _targetPrefab; 
    [SerializeField] private int _totalSuitcases = 10; 

    private GameObject currentTargetPoint; 
    private int deliveredSuitcases = 0; 
    private LevelManager _levelManager;

    private void Start()
    {
        SpawnSuitcase();
    }

    private void SpawnSuitcase()
    {
        if (deliveredSuitcases < _totalSuitcases)
        {
            int randomIndex = Random.Range(0, _spawnSuitcasePoints.Length);
            Instantiate(_suitcasePrefab, _spawnSuitcasePoints[randomIndex].position, Quaternion.identity);
        }
        else
        {
            LoadVictoryScene();
        }
    }

    public void OnSuitcasePickedUp()
    {
        if (currentTargetPoint == null)
        {
            int randomIndex = Random.Range(0, _spawnTargetPoints.Length);
            currentTargetPoint = Instantiate(_targetPrefab, _spawnTargetPoints[randomIndex].position, Quaternion.identity);
        }
    }

    public void OnSuitcaseDelivered()
    {
        deliveredSuitcases++;
        if (currentTargetPoint != null)
        {
            Destroy(currentTargetPoint);
        }
        SpawnSuitcase();
    }

    private void LoadVictoryScene()
    {
        _levelManager.LoadVictoryScene();
    }
}
