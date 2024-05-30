using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        float spawnPosX = Random.Range(-10f, 10f);
        float spawnPosY = Random.Range(-4f, 4f);

        Instantiate(enemyPrefab, new Vector3(spawnPosX, spawnPosY, 0), Quaternion.identity);
    }
}

