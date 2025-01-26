using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{

    public UnityEvent notEnoughMoney;

    public float bubbles;
    public static Wallet instance;
   
    void Awake()
    {
        LoadPrefs();
        if( instance == null){
            DontDestroyOnLoad(this);
            instance = this;
        }
        else{
            Destroy(this);
        }
    }
    public void AddBubbles(float _popped)
    {
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

/*
public class Wallet : MonoBehaviour
{
    public UnityEvent notEnoughMoney;

    public float bubbles;
    public static Wallet instance;

    void Awake()
    {
        LoadPrefs();
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddBubbles(float _popped)
    {
        bubbles += _popped;
        SavePrefs();
    }

    public bool SubBubbles(float _sub)
    {
        if (bubbles >= _sub)
        {
            bubbles -= _sub;
            SavePrefs();
            return true; // Deduction successful
        }
        else
        {
            notEnoughMoney.Invoke(); // Trigger event if insufficient funds
            return false; // Deduction failed
        }
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
*/