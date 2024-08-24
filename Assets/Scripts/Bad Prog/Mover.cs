using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private float _speed;
    private int _indexWaypoint;

    private void Start()
    {
        _indexWaypoint = 0;
    }

    private void Update()
    {
        var currentWaypoint = _waypoints[_indexWaypoint];
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, _speed * Time.deltaTime);

        if (transform.position == currentWaypoint.position)
        {
            ChooseNextWaypoint();
        }
    }

    private void ChooseNextWaypoint()
    {
        _indexWaypoint = ++_indexWaypoint % _waypoints.Length;
        Vector3 thisPointVector = _waypoints[_indexWaypoint].transform.position;
        transform.forward = thisPointVector - transform.position;
    }
}
