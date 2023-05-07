using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamageToPlayer : MonoBehaviour
{
    public float damageAmount = 10f;
    public float damageRange = 1f;
    public float damageInterval = 0.5f; // Time between damage
    
    private float lastDamageTime = -1f;
    public PlayerHealthHandler playerHealth;
    
    private void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealthHandler>();
    }

    private void Update()
    {
        // Check if player is in range
        float distanceToPlayer = Vector3.Distance(transform.position, playerHealth.transform.position);
        if (distanceToPlayer <= damageRange)
        {
            // Check if enough time has passed since last damage tick
            if (Time.time - lastDamageTime > damageInterval)
            {
                // Damage the player
                playerHealth.TakeDamage(damageAmount);
                lastDamageTime = Time.time;
            }
        }
    }
}
