using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

/*
public class BubbleFloat : MonoBehaviour
{
    static float t= 0;
    private bool setDirection = false;
    public UnityEvent OnClick;

    private float directionfloat;
    public float s = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    
    void Update()
    {
         t += Time.deltaTime;
         if(!setDirection){
            directionfloat = Random.Range(-0.1f, 0.1f);
            setDirection = true;
         }

         if(setDirection){
             transform.position = new Vector3(Mathf.Clamp(Mathf.Lerp(transform.position.x,transform.position.x+directionfloat, t/1 ),-5f,5f), transform.position.y +(5f*Time.deltaTime), transform.position.z);
         }  

         if(t>1){
            setDirection = false;
            t = 0f;
         }

        //transform.position = new Vector3(Mathf.Clamp(transform.position.x + Random.Range(-.2f, .2f),-5f,5f), transform.position.y +0.1f, transform.position.z);

        if(transform.position.y > 20)
        {
            Destroy(gameObject);
        }


    }

    public void Clicked()
    {
        OnClick.Invoke();
        Destroy(gameObject);
    }

    
}
*/
public class BubbleFloat : MonoBehaviour
{
    public UnityEvent OnClick; // Event to trigger on bubble click
    public GameObject PopupTextPrefab; // Reference to the popup text prefab
    public Canvas PopupCanvas; // Reference to the canvas for popup text

    private float t = 0;
    private bool setDirection = false;
    private float directionfloat = 0;

    void Start()
    {
        if (PopupCanvas == null)
        {
            // Automatically find a Canvas in the scene if not assigned
            PopupCanvas = FindObjectOfType<Canvas>();
            if (PopupCanvas == null)
            {
                Debug.LogError("No Canvas found in the scene for PopupText!");
            }
        }
    }

    void FixedUpdate()
    {
          t += Time.deltaTime;
         if(!setDirection){
            directionfloat = Random.Range(-0.1f, 0.1f);
            setDirection = true;
         }

         if(setDirection){
             transform.position = new Vector3(Mathf.Clamp(Mathf.Lerp(transform.position.x,transform.position.x+directionfloat, t/1 ),-5f,5f), transform.position.y, transform.position.z);
         }  

         if(t>1){
            setDirection = false;
            t = 0f;
         }

        // Destroy if bubble moves off-screen
        if (transform.position.y > 20)
        {
            Destroy(gameObject);
        }
    }

    public void Clicked()
    {
        OnClick.Invoke(); // Trigger any additional functionality
        Destroy(gameObject); // Destroy the bubble
    }
}



