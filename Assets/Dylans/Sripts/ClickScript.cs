using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;


public class ClickScript : MonoBehaviour
{
    public Wallet wallet; // Reference to WalletManager
    public int bubblesPerClick = 1; // Amount of bubbles added per click
    public AudioClip[] sounds; // Array of random sounds to play
    private AudioSource audioSource; // Reference to the AudioSource
    [Range(0.1f, 0.5f)] public float volumeChangeMult = 0.2f;
    public float pitchChangeMult = 0.2f;

    private GameObject background;

    private BubbleFloat currentBubble; // Store the clicked bubble for scaling back

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

                    // Store the reference to scale back later
                    //currentBubble = bubbleFloat;

                    /*// Scale up the bubble and reset its scale after completion
                    bubbleFloat.transform.DOBlendableScaleBy(bubbleFloat.transform.localScale * 1.05f, 0.05f).OnComplete(() =>
                    {
                        bubbleFloat.transform.DOBlendableScaleBy(bubbleFloat.transform.localScale / 1.05f, 0.05f);
                    });*/

                    background.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(BackgroundScaleBack);

                    // Play a random sound of tha 10
                    PlayRandomSound();
                }
            }
        }
    }

    private void BackgroundScaleBack()
    {
        background.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), -0.05f);
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