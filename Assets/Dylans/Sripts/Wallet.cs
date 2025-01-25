using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{

    public UnityEvent notEnoughMoney;

    public int bubbles = 0;

   

    public void AddBubbles(int _popped){
        bubbles += _popped;
    }

    public void SubBubbles(int _sub){

        if(bubbles - _sub <0 ){
            notEnoughMoney.Invoke();
        }
        else{
            bubbles -= _sub;
        }

    }
}
