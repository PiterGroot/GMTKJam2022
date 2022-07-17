using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public bool isInWave;
    private int currentWave = -1;
    private GameManager gameManager;
    private Vector2 spawnPos;

    [SerializeField] private bool startSpawningOnAwake;
    [SerializeField] private float startTimer;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] private float waveInterval = 5;
    [SerializeField] private Wave[] waves;

    public List<GameObject> enemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if (startSpawningOnAwake) Invoke(nameof(WaveLoop), startTimer);
        gameManager = FindObjectOfType<GameManager>();
        spawnPos = gameManager.GetWayPoint(0).position;
    }

    private void WaveLoop()
    {
        currentWave++;
        if (currentWave < waves.Length)
        {
            isInWave = true;
            StartCoroutine(SpawnEnemy());
        }
    }
    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < waves[currentWave].Enemy.Length; i++)
        {
            GameObject enemy = Instantiate(waves[currentWave].Enemy[i], spawnPos, Quaternion.identity);
            enemies.Add(enemy);
            yield return new WaitForSeconds(spawnInterval);
        }
        isInWave = false;
        Invoke(nameof(WaveLoop), waveInterval);
    }
    private void Update()
    {
        if (currentWave == waves.Length && enemies.Count == 0)
        {
            print("Victory");
        }
    }
}


[System.Serializable]
public class Wave
{
    public GameObject[] Enemy;
}
