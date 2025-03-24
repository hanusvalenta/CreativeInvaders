using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 5f;

    public GameObject[] enemyPrefabs;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs != null && enemyPrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
