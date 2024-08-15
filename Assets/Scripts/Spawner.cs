using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _delay = 2f;

    private void Start()
    {
        StartCoroutine(nameof(Spawn), _delay);
    }

    private SpawnPoint GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }

    private IEnumerator Spawn(float delay)
    {
        WaitForSeconds waitTime = new WaitForSeconds(delay);

        while (true)
        {
            GetRandomSpawnPoint().SpawnEnemy();

            yield return waitTime;
        }
    }
}
