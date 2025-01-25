using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRadius : MonoBehaviour
{
    public float startRadius = 0.2f;
    public float currentRadius;
    public float maxRadius = 10.1f;
    // Start is called before the first frame update
    void Start()
    {
        currentRadius = startRadius;
    }

    // Update is called once per frame
    void Update()
    {
        currentRadius += 0.05f;
        if (this.gameObject.transform.localScale.x < maxRadius)
        {
            
            this.gameObject.transform.localScale = new Vector3(currentRadius,currentRadius,0.0f);
        }
        if (currentRadius >= maxRadius)
        {
            Debug.Log(this);
            Destroy(gameObject);
        }
    }
}
