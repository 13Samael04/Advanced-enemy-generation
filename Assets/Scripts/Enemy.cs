using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    public event Action<Enemy> Died;

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Target target))
        {
            Died?.Invoke(this);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.LookAt(_target.position);
    }
}
