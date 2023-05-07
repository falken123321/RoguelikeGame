using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float bulletLifetime;
    public SFXController sfx;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Mouse position
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.z;
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);
            
            //Final shoot direction (Target Position - Player Position)
            Vector3 shootDirection = targetPos - transform.position;
            shootDirection.z = 0f;
            shootDirection.Normalize();
            
            //Create bullet, and set velocity
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<bulletController>().Pd = this.GetComponent<CharacterAttributes>().toPlayerData();
            
            //Sound 
            sfx.PlayShootingSound();
            
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            Vector2 bulletDirection = shootDirection * bulletSpeed;
            bulletRB.velocity = bulletDirection;

            Destroy(bullet, bulletLifetime);
        }
    }
}