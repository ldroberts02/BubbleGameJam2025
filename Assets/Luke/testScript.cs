using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class testScript : MonoBehaviour
{
    public GameObject shopObject;
    public GameObject textObject;
    public TMP_Text testText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        testText.text = Wallet.instance.bubbles.ToString();
    }
    public void buttonTest()
    {
        Debug.Log("Button");
        Wallet.instance.SubBubbles(1);
    }
    public void shopButtonToggle()
    {
        if (shopObject != null)
        {
            if (!shopObject.activeSelf)
            {
                Debug.Log("Not Active, Setting active");
                shopObject.SetActive(true);
                return;
            }
            else if (shopObject.activeSelf)
            {
                Debug.Log("Active, Setting Not active");
                shopObject.SetActive(false);
                return;
            }
        }
        if (shopObject == null)
        {
            Debug.LogError("Shop Null!");
        }
    }
}
