using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{

    public UnityEvent notEnoughMoney;

    public int bubbles;
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
    public void AddBubbles(int _popped){
        bubbles += _popped;
        SavePrefs();
    }

    public void SubBubbles(int _sub){

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
        PlayerPrefs.SetInt("BubblesPopped", bubbles);
        PlayerPrefs.Save();
    }
 
    public void LoadPrefs()
    {
        bubbles = PlayerPrefs.GetInt("BubblesPopped", 0); 
    }

}
