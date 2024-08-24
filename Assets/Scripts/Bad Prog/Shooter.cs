using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _delay;

    private Transform _target;

    private void Start()
    {
        StartCoroutine(ShootingWorker(_delay));
    }

    private IEnumerator ShootingWorker(float delay)
    {
        WaitForSeconds waitTime = new WaitForSeconds(delay);
        Rigidbody rigidbody;

        while (enabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
            newBullet.transform.up = direction;
            rigidbody = newBullet.GetComponent<Rigidbody>();
            rigidbody.velocity = direction * _speed;

            yield return waitTime;
        }
    }
}
