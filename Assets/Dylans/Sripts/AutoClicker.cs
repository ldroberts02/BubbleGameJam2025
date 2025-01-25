using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    public float addToBubbles;
    private float currentTime= 0;
    private Wallet wallet;

    void Start()
    {
        wallet = GameObject.Find("WalletManager").GetComponent<Wallet>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >0.2){
            wallet.AddBubbles(addToBubbles);
            currentTime = 0.0f;
        }
    }

    public void UpgradeClicker(){
        addToBubbles *= 1.1f;
    }
}
