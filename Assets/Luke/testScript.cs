using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    public GameObject shopObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonTest()
    {
        Debug.Log("Button");
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
