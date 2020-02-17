using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    public static AttackerSpawner instance { get; private set; }

    public Transform[] spawnPoints;
    [SerializeField] Attacker[] attackersPrefab;

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

            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var attackerIndex = UnityEngine.Random.Range(0, attackersPrefab.Length);

        Spawn(attackersPrefab[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        int randomSpawn = UnityEngine.Random.Range(0, spawnPoints.Length);

        Attacker enemy = Instantiate(myAttacker, spawnPoints[randomSpawn].position, Quaternion.identity) as Attacker;
        enemy.transform.parent = spawnPoints[randomSpawn];
    }

    public void StopSpawner()
    {
        canSpawn = false;
    }
}
