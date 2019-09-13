using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject jumperPrefab;

    float lastSpawnTime;

    [Range(0.5f, 5)]
    public float spawnDelay = 3.0f;
    [Range(0.2f, 1)]
    public float deltaRandomSpawn = 0.5f;

    private float randomSpawnDelay;
    private bool stop = false;


    public List<GameObject> jumpers = new List<GameObject>();

    private void Start()
    {
        if (jumperPrefab == null)
            return;
        randomSpawnDelay = spawnDelay;
        SpawnJumper();
    }
    private void Update()
    {
        if(!stop && Time.time > lastSpawnTime + randomSpawnDelay)
        {
            SpawnJumper();
        }
    }

    private void SpawnJumper()
    {
        lastSpawnTime = Time.time;
        randomSpawnDelay = Random.Range(spawnDelay - deltaRandomSpawn, spawnDelay + deltaRandomSpawn);
        GameObject jumper = Instantiate(jumperPrefab);

        jumpers.Add(jumper);
        JumperController jumperController = jumper.GetComponentInChildren<JumperController>();

    }
    private void DestroyJumper(GameObject jumper)
    {
        jumpers.Remove(jumper);
        Destroy(jumper);
    }
    public void Stop()
    {
        stop = true;
    }
 }
