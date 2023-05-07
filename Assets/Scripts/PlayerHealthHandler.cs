using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour
{
    
    public double healthPoint { get; set; }
    public double maxHealth;
    public Healthbar healthBar;
    public GameObject gameOverCanvas;

    public GameObject gainedCoins;
    void Start()
    {
        maxHealth = gameObject.GetComponent<CharacterAttributes>().health;
        healthPoint = maxHealth;
    }
    void Update()
    {
        if (healthPoint <= 0)
        {
            CharacterAttributes ca = gameObject.GetComponent<CharacterAttributes>();
            gameObject.GetComponent<saveBalance>().saveCurrentBalance((float)ca.balance);
            gainedCoins.GetComponent<gainedCoinsHandler>().updateGainedCoins();
            gameOverCanvas.SetActive(true);
            gameObject.SetActive(false);
        }
        
        healthBar.SetSliderValue((float)healthPoint,(float)maxHealth);
    }
    
    public void TakeDamage(float enemyDamage)
    {
        healthPoint -= enemyDamage;
    }
}
