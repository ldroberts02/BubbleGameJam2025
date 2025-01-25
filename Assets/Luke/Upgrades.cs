using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onPurchase(int id = -1)
    {
        switch(id) //what to do for each purchase, call the function alongside the number of the upgrade
        {
            case 0:
            //upgrade type 1 - 
            break;
            case 1:
            //upgrade type 2 -
            break;
            case 3:
            //upgrade type 4 -
            break;
            default:
            break;
        }
    }
}
