using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance { get; private set; }

    public Transform[] spawnPoints;
    [SerializeField] Enemy enemyPrefab;

    [SerializeField] float minSpawnDelay = 1, maxSpawnDelay = 5;

    private bool canSpawn = true;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(StartSpawn());    
    }
    
    IEnumerator StartSpawn()
    {
        while (canSpawn)
        {
            float timeToWaitBetweenSpawns = UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(timeToWaitBetweenSpawns);

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int randomSpawn = UnityEngine.Random.Range(0, spawnPoints.Length);

        Enemy enemy = Instantiate(enemyPrefab, spawnPoints[randomSpawn].position, Quaternion.identity) as Enemy;
        enemy.transform.parent = spawnPoints[randomSpawn];
    }
}
