using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class ClickScript : MonoBehaviour
{
    public Wallet wallet;

    public int bubblesPerClick = 1;
    private BubbleFloat bubbleFloat;
    // Start is called before the first frame update
    void Start()
    {
        wallet = GameObject.Find("WalletManager").GetComponent<Wallet>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
         if (hit.collider !=null) {
             hit.collider.gameObject.GetComponent<BubbleFloat>().Clicked();
             wallet.AddBubbles(bubblesPerClick);
            }
        }
    }
}
*/

public class ClickScript : MonoBehaviour
{
    public Wallet wallet; // Reference to WalletManager
    public int bubblesPerClick = 1; // Amount of bubbles added per click
    public AudioClip[] sounds; // Array of random sounds to play
    private AudioSource audioSource; // Reference to the AudioSource
    [Range(0.1f, 0.5f)] public float volumeChangeMult = 0.2f;
    public float pitchChangeMult = 0.2f;

    void Start()
    {
        // Get the WalletManager reference
        wallet = GameObject.Find("WalletManager").GetComponent<Wallet>();

        // Add an AudioSource component if one isn't already attached
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            // If the ray hits something
            if (hit.collider != null)
            {
                // Check if the clicked object has a BubbleFloat component
                BubbleFloat bubbleFloat = hit.collider.gameObject.GetComponent<BubbleFloat>();
                if (bubbleFloat != null)
                {
                    // Perform the bubble click action
                    bubbleFloat.Clicked();
                    wallet.AddBubbles(bubblesPerClick);

                    // Play a random sound
                    PlayRandomSound();
                }
            }
        }
    }

    void PlayRandomSound()
    {
        if (sounds.Length > 0)
        {
            audioSource.clip = sounds[Random.Range(0, sounds.Length)];
            audioSource.pitch = Random.Range(1 - pitchChangeMult, 1 + pitchChangeMult);
            audioSource.volume = Random.Range(1 - volumeChangeMult, 1);
            audioSource.PlayOneShot(audioSource.clip);
        }
        else
        {
            Debug.LogWarning("No sounds assigned in the array!");
        }
    }
}