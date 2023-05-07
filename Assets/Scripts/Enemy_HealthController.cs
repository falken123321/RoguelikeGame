using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy_HealthController : MonoBehaviour, IEnemy
{
    public double healthPoint { get; set; }
    public double damage { get; set; }
    public double resistance { get; set; }
    public GameObject firePrefab;
    public Healthbar healthBar;
    public double maxHealth;
    public GameObject Coin;

    public void Update()
    {
        if (healthPoint <= 0)
        {
            killEnemy();
        }
        
        
        healthBar.SetSliderValue((float)healthPoint,(float)maxHealth);
    }

    public void killEnemy()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnCoin();
        }
        GameObject.Find("WaveHandler").GetComponent<WaveController>().RegisterEnemyDeath();
        Destroy(this.gameObject);
    }

    private void SpawnCoin()
    {
        GameObject coin = Instantiate(Coin, transform.position, Quaternion.identity);
        Rigidbody2D coinRigidbody = coin.GetComponent<Rigidbody2D>();

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        coinRigidbody.AddForce(randomDirection * 5f, ForceMode2D.Impulse);
    }
    
    public void takeDamage(PlayerData playerData)
    {
        healthPoint -= playerData.CalculateBasicDamage(resistance);
    }

    public void Start()
    {
        healthPoint = maxHealth;
        
        damage = 2f;
        resistance = 3;
    }


    public IEnumerator TakeFireDamageOverTime(double damagePerSecond, double durationInSeconds)
    {
        GameObject fireDamageObject = Instantiate(firePrefab, transform.position, Quaternion.identity);
        fireDamageObject.transform.parent = gameObject.transform;
        Destroy(fireDamageObject, (float)durationInSeconds);
    
        double timeElapsed = 0.0f;
        double lastHit = 0.0f;
        while (timeElapsed < durationInSeconds)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > lastHit + 1)
            {
                healthPoint -= damagePerSecond;
                lastHit = timeElapsed;
                healthBar.SetSliderValue((float)healthPoint,100f);
            }
            yield return null;
        }
    }
    
    
}
