using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public NewClickScript newClickScript; // Reference to NewClickScript
    public int upgradeCost = 10; // Cost of the upgrade

    public void UpgradeClick()
    {
        if (newClickScript.wallet.bubbles >= upgradeCost)
        {
            newClickScript.wallet.SubBubbles(upgradeCost); // Deduct bubbles
            //newClickScript.UpgradeClickPower(); // Increase bubbles per click
        }
        else
        {
            Debug.Log("Not enough bubbles to upgrade!");
        }
    }
}
