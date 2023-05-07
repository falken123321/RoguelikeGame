using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeAttribute : MonoBehaviour
{
    //For now, all prices have a constant value. This should be scaled at some point.
    public float upgradePrice;
    public GameObject allAttributesText;
    
    private void Start()
    {
        PlayerData pd = loadPlayerData();
        loadNewPrice();
    }

    public void upgrade(string attributeToBeUpgraded)
    {
        PlayerData pd = loadPlayerData();
        if (pd.balance < upgradePrice)
        {
            return;
        }
            switch (attributeToBeUpgraded)
        {
            case "health":
                pd.health += 10;
                break;
            case "health_regen":
                pd.health_regen += 1;
                break;
            case "movement_Speed":
                pd.movement_Speed += .2;
                break;
            case "attack_speed":
                pd.attack_speed += .2;
                break;
            case "base_damage":
                pd.base_damage += 5;
                break;
            case "fire_damage":
                pd.fire_damage += 2;
                break;
            case "poison_damage":
                pd.poison_damage += 2;
                break;
            case "critical_multiplayer":
                pd.critical_multiplayer += 0.5;
                break;
            case "critical_chance":
                pd.critical_chance += 0.1;
                break;
            case "knockback":
                pd.knockback += 1;
                break;
            default: 
                pd.balance += upgradePrice; //Adding this since the user is charged no matter which case is picked.
                Debug.Log("Invalid attribute name.");
                break;
        }

        pd.balance -= upgradePrice;
        savePlayerData(pd);
        allAttributesText.GetComponent<LoadAllAttributesForText>().loadCharacterAttributesForText();
    }

    public void loadNewPrice()
    {
        transform.Find("PriceText").GetComponent<TextMeshProUGUI>().text = upgradePrice + " gold";
    }

    public PlayerData loadPlayerData()
    {
        return CharacterVariableLoader.ReadCharacterAttributes();
    }
    
    public void savePlayerData(PlayerData pd)
    {
        CharacterVariableLoader.WriteCharacterAttributes(pd);
    }
}
