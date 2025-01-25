using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Upgrades : MonoBehaviour
{
    public GameObject upgradeOne;
    public float upgradePriceOne = 10.0f;
    public int upgradeOneAmnt = 0;
    public TMP_Text upgradeOnePriceText;

    public GameObject upgradeTwo;
    public float upgradePriceTwo = 100.0f;
    public int upgradeTwoAmnt = 0;
    public TMP_Text upgradeTwoPriceText;

    public GameObject upgradeThree;
    public float upgradePriceThree = 1000.0f;
    public int upgradeThreeAmnt = 0;
    public TMP_Text upgradeThreePriceText;

    public GameObject upgradeFour;
    public float upgradePriceFour = 10000.0f;
    public int upgradeFourAmnt = 0;
    public TMP_Text upgradeFourPriceText;

    public GameObject upgradeFive;
    public float upgradePriceFive = 10000.0f;
    public int upgradeFiveAmnt = 0;
    public TMP_Text upgradeFivePriceText;

    public GameObject upgradeSix;
    public float upgradePriceSix = 10000.0f;
    public int upgradeSixAmnt = 0;
    public TMP_Text upgradeSixPriceText;

    public GameObject upgradeSeven;
    public float upgradePriceSeven = 10000.0f;
    public int upgradeSevenAmnt = 0;
    public TMP_Text upgradeSevenPriceText;

    public GameObject upgradeEight;
    public float upgradePriceEight = 10000.0f;
    public int upgradeEightAmnt = 0;
    public TMP_Text upgradeEightPriceText;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onPurchase(int id = -1)
    {
        switch (id) //what to do for each purchase, call the function alongside the number of the upgrade
        {
            case 0:
                //upgrade type 1 -
                Debug.Log("Case 0 - Upgrade 1");
                if (upgradePriceOne < Wallet.instance.bubbles)
                {
                    Wallet.instance.SubBubbles(upgradePriceOne);
                    if (upgradeOne.activeSelf == false)
                    {
                        upgradeOne.SetActive(true);
                        upgradePriceOne *= 1.2f;
                        upgradePriceOne = Mathf.Round(upgradePriceOne);
                        upgradeOneAmnt++;
                    }
                    if (upgradeOne.activeSelf == true)
                    {
                        upgradePriceOne *= 1.2f;
                        upgradePriceOne = Mathf.Round(upgradePriceOne);
                        upgradeOneAmnt++;
                    }
                    upgradeOnePriceText.text = (upgradePriceOne).ToString();
                }
                break;
            case 1:
                //upgrade type 2 -
                Debug.Log("Case 1 - Upgrade 2");
                if (upgradePriceTwo < Wallet.instance.bubbles)
                {
                    Wallet.instance.SubBubbles(upgradePriceTwo);
                    if (upgradeTwo.activeSelf == false)
                    {
                        upgradeTwo.SetActive(true);
                        upgradePriceTwo *= 1.2f;
                        upgradePriceTwo = Mathf.Round(upgradePriceTwo);
                        upgradeTwoAmnt++;
                    }
                    if (upgradeTwo.activeSelf == true)
                    {
                        upgradePriceTwo *= 1.2f;
                        upgradePriceTwo = Mathf.Round(upgradePriceTwo);
                        upgradeTwoAmnt++;
                    }
                    upgradeTwoPriceText.text = (upgradePriceTwo).ToString();
                }
                break;
            case 2:
                //upgrade type 3 -
                Debug.Log("Case 2 - Upgrade 3");
                if (upgradePriceThree < Wallet.instance.bubbles)
                {
                    Wallet.instance.SubBubbles(upgradePriceThree);
                    if (upgradeThree.activeSelf == false)
                    {
                        upgradeThree.SetActive(true);
                        upgradePriceThree *= 1.2f;
                        upgradePriceThree = Mathf.Round(upgradePriceThree);
                        upgradeThreeAmnt++;
                    }
                    if (upgradeThree.activeSelf == true)
                    {
                        upgradePriceThree *= 1.2f;
                        upgradePriceThree = Mathf.Round(upgradePriceThree);
                        upgradeThreeAmnt++;
                    }
                    upgradeThreePriceText.text = (upgradePriceThree).ToString();
                }
                break;
            case 3:
                //upgrade type 4 -
                Debug.Log("Case 3 - Upgrade 4");
                if (upgradePriceFour < Wallet.instance.bubbles)
                {
                    Wallet.instance.SubBubbles(upgradePriceFour);
                    if (upgradeFour.activeSelf == false)
                    {
                        upgradeFour.SetActive(true);
                        upgradePriceFour *= 1.2f;
                        upgradePriceFour = Mathf.Round(upgradePriceFour);
                        upgradeFourAmnt++;
                    }
                    if (upgradeFour.activeSelf == true)
                    {
                        upgradePriceFour *= 1.2f;
                        upgradePriceFour = Mathf.Round(upgradePriceFour);
                        upgradeFourAmnt++;
                    }
                    upgradeFourPriceText.text = (upgradePriceFour).ToString();
                }
                break;
            case 4:
                //upgrade type 5 -
                Debug.Log("Case 4 - Upgrade 5");
                if (upgradePriceFive < Wallet.instance.bubbles)
                {
                    Wallet.instance.SubBubbles(upgradePriceFive);
                    if (upgradeFive.activeSelf == false)
                    {
                        upgradeFive.SetActive(true);
                        upgradePriceFive *= 1.2f;
                        upgradePriceFive = Mathf.Round(upgradePriceFive);
                        upgradeFiveAmnt++;
                        
                    }
                    if (upgradeFive.activeSelf == true)
                    {
                        upgradePriceFive *= 1.2f;
                        upgradePriceFive = Mathf.Round(upgradePriceFive);
                        upgradeFiveAmnt++;
                        upgradeFive.GetComponent<AutoClicker>().UpgradeClicker();
                    }
                    upgradeFivePriceText.text = (upgradePriceFive).ToString();
                }
                break;
            case 5:
            //upgrade type 6 -
            Debug.Log("Case 5 - Upgrade 6");
                if (upgradePriceSix < Wallet.instance.bubbles)
                {
                    Wallet.instance.SubBubbles(upgradePriceSix);
                    if (upgradeSix.activeSelf == false)
                    {
                        upgradeSix.SetActive(true);
                        upgradePriceSix *= 1.2f;
                        upgradePriceSix = Mathf.Round(upgradePriceSix);
                        upgradeSixAmnt++;
                    }
                    if (upgradeSix.activeSelf == true)
                    {
                        upgradePriceSix *= 1.2f;
                        upgradePriceSix = Mathf.Round(upgradePriceSix);
                        upgradeSixAmnt++;
                        upgradeSix.GetComponent<AutoClicker>().UpgradeClicker();
                    }
                    upgradeSixPriceText.text = (upgradePriceSix).ToString();
                }
                break;
            case 6:
            //upgrade type 7 -
            Debug.Log("Case 6 - Upgrade 7");
                if (upgradePriceSeven < Wallet.instance.bubbles)
                {
                    Wallet.instance.SubBubbles(upgradePriceSeven);
                    if (upgradeSeven.activeSelf == false)
                    {
                        upgradeSeven.SetActive(true);
                        upgradePriceSeven *= 1.2f;
                        upgradePriceSeven = Mathf.Round(upgradePriceSeven);
                        upgradeSevenAmnt++;
                    }
                    if (upgradeSeven.activeSelf == true)
                    {
                        upgradePriceSeven *= 1.2f;
                        upgradePriceSeven = Mathf.Round(upgradePriceSeven);
                        upgradeSevenAmnt++;
                        upgradeSeven.GetComponent<AutoClicker>().UpgradeClicker();
                    }
                    upgradeSevenPriceText.text = (upgradePriceSeven).ToString();
                }
                break;
            case 7:
                //upgrade type 8 -
                Debug.Log("Case 7 - Upgrade 8");
                if (upgradePriceEight < Wallet.instance.bubbles)
                {
                    Wallet.instance.SubBubbles(upgradePriceEight);
                    if (upgradeEight.activeSelf == false)
                    {
                        upgradeEight.SetActive(true);
                        upgradePriceEight *= 1.2f;
                        upgradePriceEight = Mathf.Round(upgradePriceEight);
                        upgradeEightAmnt++;
                    }
                    if (upgradeEight.activeSelf == true)
                    {
                        upgradePriceEight *= 1.2f;
                        upgradePriceEight = Mathf.Round(upgradePriceEight);
                        upgradeEightAmnt++;
                        upgradeEight.GetComponent<AutoClicker>().UpgradeClicker();
                    }
                    upgradeEightPriceText.text = (upgradePriceEight).ToString();
                }
                break;
            default:
                break;
        }
    }
}
