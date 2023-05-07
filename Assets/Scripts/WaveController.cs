using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public int SpawnAmount;
    public int SpawnIncreasePerWave;
    public GameObject enemy;
    private int waveCount;
    private int enemiesAlive;
    private float elapsedTime;
    public TextMeshProUGUI waveText;
    private bool EnemiesAboutToSpawn = false;
    

    private void Start()
    {
        waveCount = 1;
        enemiesAlive = 0;

        SpawnWave();
    }
    
    private void Update()
    {
        if (enemiesAlive == 0 && !EnemiesAboutToSpawn)
        {
            SpawnAmount += SpawnIncreasePerWave;
            SpawnWave();
        }

    }
    
    private void SpawnWave()
    {
        EnemiesAboutToSpawn = true;
        waveText.SetText("Wave " + waveCount);
        waveCount++;
        Invoke("SpawnEnemies", 5f); //5 Sec delay for enemies to spawn
    }

    private void SpawnEnemies()
    {
        waveText.SetText("");
        for (int i = 0; i < SpawnAmount; i++)
        {
            SpawnEnemy();
        }

        // Clear wave text
        waveText.SetText("");
    }
    private void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
        enemiesAlive++;
    }
    
    public void RegisterEnemyDeath()
    {
        enemiesAlive -= 1;
        EnemiesAboutToSpawn = false;
    }
}

