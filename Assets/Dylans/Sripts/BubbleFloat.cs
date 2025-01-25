using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BubbleFloat : MonoBehaviour
{

    public UnityEvent OnClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    
    void FixedUpdate()
    {

        transform.position = new Vector3(Mathf.Clamp(transform.position.x + Random.Range(-.2f, .2f),-5f,5f), transform.position.y +0.1f, transform.position.z);

        if(transform.position.y > 20){
            Destroy(gameObject);
        }


    }

    public void Clicked()
    {
        OnClick.Invoke();
        Destroy(gameObject);
    }

    
}
