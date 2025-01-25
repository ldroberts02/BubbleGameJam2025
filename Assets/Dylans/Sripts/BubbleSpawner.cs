 using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class BubbleSpawner : MonoBehaviour
{

    public GameObject bubble;
    public SpawnerSpawner spawner;
    public float spawnRate = 0.2f;

    public float currentTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        spawner = transform.parent.gameObject.transform.parent.gameObject.GetComponent<SpawnerSpawner>();
        spawnRate = Random.Range(0.1f/spawner.spawnRateModifier, 0.75f/spawner.spawnRateModifier);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >spawnRate){
            Instantiate(bubble,transform);
            currentTime = 0;
            spawnRate = Random.Range(0.5f/spawner.spawnRateModifier, 0.75f/spawner.spawnRateModifier);
        }
    }
}
