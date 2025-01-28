using TMPro;
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
/*
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
         if(!setDirection)
         {
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
*/
public class BubbleFloat : MonoBehaviour
{
    public UnityEvent OnClick; // Event to trigger on bubble click
    public GameObject PopupTextPrefab; // Reference to the popup text prefab
    public Canvas PopupCanvas; // Reference to the canvas for popup text
    public AudioClip[] sounds; // Array of random sounds to play
    private AudioSource audioSource; // Reference to the AudioSource
    [Range(0.1f, 0.5f)] public float volumeChangeMult = 0.2f;
    public float pitchChangeMult = 0.2f;


    private float t = 0;
    private bool setDirection = false;
    private float directionfloat = 0;
    private NewClickScript clickScript;

    void Start()
    {
        clickScript = GameObject.Find("Clicker").GetComponent<NewClickScript>();
        // Ensure Canvas is assigned or auto-detected
        if (PopupCanvas == null)
        {
            PopupCanvas = FindObjectOfType<Canvas>();
            if (PopupCanvas == null)
            {
                Debug.LogError("No Canvas found in the scene for PopupText!");
            }
        }

        // Add or get an AudioSource for sound playback
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void FixedUpdate()
    {
        t += Time.deltaTime;

        if (!setDirection)
        {
            directionfloat = Random.Range(-0.1f, 0.1f);
            setDirection = true;
        }

        if (setDirection)
        {
            transform.position = new Vector3
            (
                Mathf.Clamp(Mathf.Lerp(transform.position.x, transform.position.x + directionfloat, t / 1), -5f, 5f),
                transform.position.y,
                transform.position.z
            );
        }

        if (t > 1)
        {
            setDirection = false;
            t = 0f;
        }

        // Destroy if the bubble moves off-screen
        if (transform.position.y > 20)
        {
            Destroy(gameObject);
        }
    }

    public void Clicked()
    {
        OnClick.Invoke(); 

        PlayRandomSound();

        // Display popup text
        if (PopupTextPrefab != null && PopupCanvas != null)
        {
            GameObject popup = Instantiate(PopupTextPrefab, PopupCanvas.transform);
            popup.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            popup.GetComponent<PopUpText>().amount = clickScript.bubblesPerClick;
        }
        else
        {
            Debug.LogWarning("PopupTextPrefab or PopupCanvas is not assigned!");
        }

        // Destroy the bubble
        Destroy(gameObject);
    }

    void PlayRandomSound()
    {
        if (sounds.Length > 0)
        {
            // Create a temporary GameObject for the sound
            GameObject soundObject = new GameObject("BubbleSound");
            AudioSource tempAudioSource = soundObject.AddComponent<AudioSource>();

            // Choose a random sound and configure the AudioSource
            AudioClip selectedClip = sounds[Random.Range(0, sounds.Length)];
            tempAudioSource.clip = selectedClip;
            tempAudioSource.pitch = Random.Range(1 - pitchChangeMult, 1 + pitchChangeMult);
            tempAudioSource.volume = Random.Range(1 - volumeChangeMult, 1);
            tempAudioSource.Play();

            // Destroy the temporary GameObject after the clip finishes playing
            Destroy(soundObject, selectedClip.length);
        }
        else
        {
            Debug.LogWarning("No sounds assigned in the array!");
        }
    }
}



