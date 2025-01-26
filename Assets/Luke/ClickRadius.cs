using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRadius : MonoBehaviour
{
    public float startRadius = 0.2f;
    public float currentRadius;
    public float maxRadius = 10.1f;

    private NewClickScript clickScript;
    // Start is called before the first frame update
    void Start()
    {
        clickScript = GameObject.Find("Clicker").GetComponent<NewClickScript>();
        currentRadius = startRadius;
    }

    // Update is called once per frame
    void Update()
    {
        currentRadius += 0.05f;
        if (this.gameObject.transform.localScale.x < clickScript.maxRadius)
        {
            
            this.gameObject.transform.localScale = new Vector3(currentRadius,currentRadius,0.0f);
        }
        if (currentRadius >= clickScript.maxRadius)
        {
            Debug.Log(this);
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
       other.gameObject.GetComponent<BubbleFloat>().Clicked();
       clickScript.ClickBubbleAdd();
    }

    


}
