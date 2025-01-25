 using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{

    public GameObject bubble;
    public float spawnRate = 0.2f;
    public float spawnRateModifier = 1;
    public float currentTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(0.1f*spawnRateModifier, 0.75f*spawnRateModifier);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >spawnRate){
            Instantiate(bubble,transform);
            currentTime = 0;
             spawnRate = Random.Range(0.2f*spawnRateModifier, 0.75f*spawnRateModifier);
        }
    }
}
