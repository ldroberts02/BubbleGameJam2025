using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextIncreaser : MonoBehaviour
{
    public int shopMult = 1;
    public TextMeshProUGUI numText;
    int counter;

    public void ButtonPressed(){
        counter = counter + 1*shopMult;
        numText.text = counter + "";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
