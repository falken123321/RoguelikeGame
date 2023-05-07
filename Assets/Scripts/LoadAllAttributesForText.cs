using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadAllAttributesForText : MonoBehaviour
{
    void Start()
    {
        loadCharacterAttributesForText();
    }
    public void loadCharacterAttributesForText() {
        PlayerData pd = CharacterVariableLoader.ReadCharacterAttributes();
        string textForDisplay = "Health: " + pd.health + "\n"
                                + "Health Regeneration: " + pd.health_regen + "\n"
                                + "Movement speed: " + pd.movement_Speed + "\n"
                                + "Attack speed: " + pd.attack_speed + "\n"
                                + "Base damage: " + pd.base_damage + "\n"
                                + "Fire damage: " + pd.fire_damage + "\n"
                                + "Poison damage: " + pd.poison_damage + "\n"
                                + "Critical multiplayer: " + pd.critical_multiplayer + "\n"
                                + "Critical chance: " + pd.critical_chance + "\n"
                                + "Knockback: " + pd.knockback + "\n"
                                + "Balance: " + pd.balance + "\n";
        this.gameObject.GetComponent<TextMeshProUGUI>().SetText(textForDisplay);
    }
}
