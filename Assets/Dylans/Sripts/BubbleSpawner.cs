using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{

    public GameObject bubble;
    public float spawnRate = 0.2f;
    public float currentTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >spawnRate){
            Instantiate(bubble,transform);
            currentTime = 0;
        }
    }
}
