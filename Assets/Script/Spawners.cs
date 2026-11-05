using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField] LevelData levelData;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemies;
    [SerializeField] float startInterval;
    [SerializeField] float minInterval;
    [SerializeField] float shrinkPerSecond;
    [SerializeField] int maxAlive;

    readonly List<GameObject> spawned = new List<GameObject>();
    float interval;
    float timer;

    void Start()
    {
        startInterval = levelData.StartInterval;
        minInterval = levelData.MinInterval;
        shrinkPerSecond = levelData.ShrinkPerSecond;
        maxAlive = levelData.MaxAlive;

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