using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col == null)
        {
            return;
        }

        if (col.gameObject.CompareTag("Bullet"))
        {
            PlayerData pd = (PlayerData)col.GetComponent<bulletController>().Pd;

            Enemy_HealthController hc = this.gameObject.GetComponent<Enemy_HealthController>();
            
            double fireDamage = pd.CalculateFireDamage(hc.resistance);
            double basicDamage = pd.CalculateBasicDamage(hc.resistance);
            double poisionDamage = pd.CalculatePoisonDamage(hc.resistance);

            
            hc.takeDamage(pd);
            if (pd.fire_damage != 0)
            {
                StartCoroutine(hc.TakeFireDamageOverTime(fireDamage, 3f));
            }
            if (pd.poison_damage != 0)
            {
                //TODO: Make poison damage (Basicly like Fire damage)
            }
            
            Destroy(col.gameObject);
        }
    }
}
