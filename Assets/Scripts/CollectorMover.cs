using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CollectorMover : MonoBehaviour
{
    [SerializeField] private string _waypointTag = "DrivePoint";
    [SerializeField] private float _checkInterval = 0.5f;

    private Transform[] _points;
    private NavMeshAgent _agent;
    private Transform _currentDestination;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag(_waypointTag);
        _points = new Transform[waypointObjects.Length];

        for (int i = 0; i < waypointObjects.Length; i++)
        {
            _points[i] = waypointObjects[i].transform;
        }

        if (_points.Length == 0)
        {
            Debug.LogError("Необходимо задать точки в массиве points");
            return;
        }

        SetNewDestination();
        StartCoroutine(CheckArrival());
    }

    private void SetNewDestination()
    {
        Transform randomPoint = _points[Random.Range(0, _points.Length)];

        _agent.SetDestination(randomPoint.position);
        _currentDestination = randomPoint;
    }

    private IEnumerator CheckArrival()
    {
        while (true)
        {
            yield return new WaitForSeconds(_checkInterval);

            if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    SetNewDestination();
        }
    }
}
