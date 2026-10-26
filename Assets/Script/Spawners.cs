using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemies;
    [SerializeField] float startInterval = 5.5f;
    [SerializeField] float minInterval = 3f;
    [SerializeField] float shrinkPerSecond = 0.025f; 
    [SerializeField] int maxAlive = 4;

    readonly List<GameObject> spawned = new List<GameObject>();
    float interval;
    float timer;

    void Start()
    {
        if (spawnPoints.Length == 0 || enemies.Length == 0)
        {
            enabled = false;
            return;
        }
        interval = startInterval;
        timer = 0f; 
    }

    void Update()
    {
        if (GameState.Over) return;

        interval = Mathf.Max(minInterval, interval - shrinkPerSecond * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer < interval) return;

        spawned.RemoveAll(e => e == null);
        if (spawned.Count >= maxAlive) return; 
        timer = 0f;
        Spawn();
    }

    void Spawn()
    {
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject prefab = enemies[Random.Range(0, enemies.Length)];
        spawned.Add(Instantiate(prefab, point.position, Quaternion.identity));
    }
}