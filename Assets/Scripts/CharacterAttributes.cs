using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class CharacterAttributes : MonoBehaviour 
{
    public double health;
    public double health_regen;
    public double movement_Speed;
    public double attack_speed;
    public double base_damage;
    public double fire_damage;
    public double poison_damage;
    public double critical_multiplier;
    public double critical_chance;
    public double knockback;
    public double balance;

    private void Start()
    {
        //Loading variables from save File
        PlayerData pdFromFile = CharacterVariableLoader.ReadCharacterAttributes();
        if (pdFromFile != null)
        {
            this.health = pdFromFile.health;
            this.health_regen = pdFromFile.health_regen;
            this.movement_Speed = pdFromFile.movement_Speed;
            this.attack_speed = pdFromFile.attack_speed;
            this.base_damage = pdFromFile.base_damage;
            this.fire_damage = pdFromFile.fire_damage;
            this.poison_damage = pdFromFile.poison_damage;
            this.critical_multiplier = pdFromFile.critical_multiplayer;
            this.critical_chance = pdFromFile.critical_chance;
            this.knockback = pdFromFile.knockback;
            this.balance = pdFromFile.balance;
        }
    }

    public void saveVariables()
    {
        CharacterVariableLoader.WriteCharacterAttributes(this.toPlayerData());
    }

    public PlayerData toPlayerData()
    {
        PlayerData playerData = new PlayerData();
        playerData.health = this.health;
        playerData.health_regen = this.health_regen;
        playerData.movement_Speed = this.movement_Speed;
        playerData.attack_speed = this.attack_speed;
        playerData.base_damage = this.base_damage;
        playerData.fire_damage = this.fire_damage;
        playerData.poison_damage = this.poison_damage;
        playerData.critical_multiplayer = this.critical_multiplier;
        playerData.critical_chance = this.critical_chance;
        playerData.knockback = this.knockback;
        playerData.balance = this.balance;

        return playerData;
    }
    
    //GETTER & SETTERS
    public double Health
    {
        get => health;
        set => health = value;
    }

    public double HealthRegen
    {
        get => health_regen;
        set => health_regen = value;
    }

    public double MovementSpeed
    {
        get => movement_Speed;
        set => movement_Speed = value;
    }

    public double AttackSpeed
    {
        get => attack_speed;
        set => attack_speed = value;
    }

    public double BaseDamage
    {
        get => base_damage;
        set => base_damage = value;
    }

    public double FireDamage
    {
        get => fire_damage;
        set => fire_damage = value;
    }

    public double PoisonDamage
    {
        get => poison_damage;
        set => poison_damage = value;
    }

    public double CriticalDamage
    {
        get => critical_multiplier;
        set => critical_multiplier = value;
    }

    public double CriticalChance
    {
        get => critical_chance;
        set => critical_chance = value;
    }

    public double Knockback
    {
        get => knockback;
        set => knockback = value;
    }
    
    public double Balance
    {
        get => knockback;
        set => knockback = value;
    }
}
