using TMPro;
using UnityEngine;

public class gainedCoinsHandler : MonoBehaviour
{
    public CharacterAttributes ca;
    public void updateGainedCoins()
    {
        double gainedCoins = ca.balance;
        this.gameObject.GetComponent<TextMeshProUGUI>().SetText("You have "+gainedCoins+ " Coins!");
    }

}
