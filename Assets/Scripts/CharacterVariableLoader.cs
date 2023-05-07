using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class CharacterVariableLoader : MonoBehaviour
{
    private static string filePath;

    public static void WriteCharacterAttributes(PlayerData playerData)
    {
        filePath = Application.persistentDataPath + "/playerData.txt";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        bf.Serialize(file, playerData);
        file.Close();
    }

    public static PlayerData ReadCharacterAttributes()
    {
        filePath = Application.persistentDataPath + "/playerData.txt";
        PlayerData pd;
        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            pd = (PlayerData)bf.Deserialize(file);
            file.Close();
        } else
        {
            //Default Character
            PlayerData playerData = new PlayerData();
            playerData.health = 100;
            playerData.health_regen = 0;
            playerData.movement_Speed = 3;
            playerData.attack_speed = 5;
            playerData.base_damage = 10;
            playerData.fire_damage = 0;
            playerData.poison_damage = 0;
            playerData.critical_multiplayer = 1.75f;
            playerData.critical_chance = 0;
            playerData.knockback = 0;
            playerData.balance = 9999; //Change this to 0
            WriteCharacterAttributes(playerData);
            
            return playerData;
        }
        return pd;
    }
    
}