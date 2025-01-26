using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleTimer : MonoBehaviour
{
    float time = 0;
    float maxTime = 3.25f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= maxTime)
        {
            SceneManager.LoadScene(1);
        }
    }
}
