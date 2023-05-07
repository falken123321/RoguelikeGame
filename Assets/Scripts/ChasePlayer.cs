using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChasePlayer : MonoBehaviour
{

    public GameObject player;
    public float speed;
    private float distanceToPlayer;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        moveTowardsPlayer();
    }

    public void moveTowardsPlayer()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        Vector2 directionTowardPlayer = player.transform.position - transform.position;
        directionTowardPlayer.Normalize();
        float angle = Mathf.Atan2(directionTowardPlayer.y, directionTowardPlayer.x) * Mathf.Rad2Deg;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

    }
}
