using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveBalance : MonoBehaviour
{
    public void saveCurrentBalance(float newBalance)
    {
        PlayerData pd = CharacterVariableLoader.ReadCharacterAttributes();
        pd.balance = newBalance;
        CharacterVariableLoader.WriteCharacterAttributes(pd);
    }
}
