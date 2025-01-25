using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerSpawner : MonoBehaviour
{


    public List<Transform> bubbleSpawnerPos;
    public GameObject prefab;
    public int numOfSpawner = 1;
    public float spawnRateModifier;
    public int currentSpawner= 0;


    // Start is called before the first frame update
    void Start()
    {
        //SaveData Comment Out when testing
       // numOfSpawner = PlayerPrefs.GetInt("numOfSpawner", 1);

       for(;    numOfSpawner > currentSpawner; currentSpawner++){
        Instantiate(prefab, bubbleSpawnerPos[currentSpawner]);
       }
    }

    // Update is called once per frame
    public void AddSpawner(){
        if (bubbleSpawnerPos.Count >= numOfSpawner){
            Instantiate(prefab, bubbleSpawnerPos[numOfSpawner]);
            numOfSpawner +=1;
            Save();
        }
        
    }

    void Save(){
        PlayerPrefs.SetInt("numOfSpawner", numOfSpawner);
    }
    void Reset(){
        PlayerPrefs.SetInt("numOfSpawner", 1);
    }



}
