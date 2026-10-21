using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;  
    [SerializeField] GameObject[] enemies;     
    [SerializeField] float startInterval = 5f;
    [SerializeField] float minInterval = 1.5f;
    [SerializeField] float speedUp = 0.1f;    
    [SerializeField] int maxAlive = 6;

    readonly List<GameObject> spawned = new List<GameObject>();
    float interval;
    float timer;

    void Start()
    {
        if (spawnPoints.Length == 0 || enemies.Length == 0)
        {
            Debug.LogWarning("Spawners: assign spawn points and enemy prefabs");
            enabled = false;
            return;
        }
        interval = startInterval;
        timer = startInterval;
    }

    void Update()
    {
        if (GameState.Over) return;

        timer += Time.deltaTime;
        if (timer < interval) return;
        timer = 0f;

        spawned.RemoveAll(e => e == null); 
        if (spawned.Count >= maxAlive) return;

        Spawn();
        interval = Mathf.Max(minInterval, interval - speedUp);
    }

    void Spawn()
    {
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject prefab = enemies[Random.Range(0, enemies.Length)];
        spawned.Add(Instantiate(prefab, point.position, Quaternion.identity));
    }
}