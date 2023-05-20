using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]
public class MovingThroughWaypoints : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _destinationReachedTreshold;

    private NavMeshAgent _navMeshAgent;
    private int _index = 1;

    private void OnEnable()
    {
        EventManager.OnMovingPlayerToWaypoint.AddListener(HandleMovingPlayerToWaypoint);
    }

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.gameObject.transform.position = _waypoints[0].position;
    }

    private void OnDisable()
    {
        EventManager.OnMovingPlayerToWaypoint.RemoveListener(HandleMovingPlayerToWaypoint);
    }

    private IEnumerator MovingPlayerThroughWaypoints()
    {
        _navMeshAgent.SetDestination(_waypoints[_index].position);
        _animator.SetBool("Run", true);

        while (CheckDestinationReached(_waypoints[_index].position) == false)
            yield return null;

        _index++;
        _animator.SetBool("Run", false);

        if (CheckDestinationReached(_waypoints[_waypoints.Length - 1].position))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        yield break;
    }

    private bool CheckDestinationReached(Vector3 targetPosition)
    {
        float distanceToTarget = Vector3.Distance(_navMeshAgent.transform.position, targetPosition);
        return distanceToTarget < _destinationReachedTreshold;
    }

    private void HandleMovingPlayerToWaypoint() => StartCoroutine(MovingPlayerThroughWaypoints());
}