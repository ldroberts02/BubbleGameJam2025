using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{

    public UnityEvent notEnoughMoney;

    public float bubbles;
    public static Wallet instance;
   
    void Awake(){
        LoadPrefs();
        if( instance == null){
            DontDestroyOnLoad(this);
            instance = this;
        }
        else{
            Destroy(this);
        }
    }
    public void AddBubbles(float _popped){
        bubbles += _popped;
        SavePrefs();
    }

    public void SubBubbles(float _sub){

        if(bubbles - _sub <0 ){
            notEnoughMoney.Invoke();
        }
        else{
            bubbles -= _sub;

        }
        SavePrefs();
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetFloat("BubblesPopped", bubbles);
        PlayerPrefs.Save();
    }
 
    public void LoadPrefs()
    {
        bubbles = PlayerPrefs.GetFloat("BubblesPopped", 0); 
    }

}
