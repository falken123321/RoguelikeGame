using System;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class PlayerData {
    public double health;
    public double health_regen;
    public double movement_Speed;
    public double attack_speed;
    public double base_damage;
    public double fire_damage;
    public double poison_damage;
    public double critical_multiplayer;
    public double critical_chance;
    public double knockback;
    public double balance;

    public double CalculateBasicDamage(double enemyDefense)
    {
        double totalDamage = base_damage;
        bool isCriticalHit = UnityEngine.Random.value < critical_chance;
        if (isCriticalHit)
        {
            totalDamage *= (1 + critical_multiplayer);
        }
        totalDamage -= enemyDefense;
        totalDamage = Mathf.Max(0, (float)totalDamage);

        return totalDamage;
    }
    
    public double CalculateFireDamage(double enemyResistance)
    {
        double totalDamage = fire_damage;
        totalDamage -= enemyResistance;
        totalDamage = Mathf.Max(0, (float)totalDamage);

        return totalDamage;
    }

    public double CalculatePoisonDamage(double enemyResistance)
    {
        double totalDamage = poison_damage;
        totalDamage -= enemyResistance;
        totalDamage = Mathf.Max(0, (float)totalDamage);

        return totalDamage;
    }
}