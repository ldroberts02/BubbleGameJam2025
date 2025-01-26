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

    public GameObject background; // Reference to background object

    void Start()
    {
        // Get the WalletManager reference
        if (wallet == null)
        {
            wallet = GameObject.Find("WalletManager")?.GetComponent<Wallet>();
            if (wallet == null)
            {
                Debug.LogError("WalletManager not found in the scene!");
            }
        }

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
                    wallet?.AddBubbles(bubblesPerClick);

                    // Show popup text
                    PopUpText.Create(bubblesPerClick, bubbleFloat.PopupTextPrefab, bubbleFloat.PopupCanvas);

                    // Scale the background if assigned
                    if (background != null)
                    {
                        background.transform
                            .DOScale(background.transform.localScale * 1.05f, 0.05f)
                            .OnComplete(() =>
                                background.transform.DOScale(background.transform.localScale / 1.05f, 0.05f));
                    }

                    // Play a random sound
                    PlayRandomSound();
                }
            }
        }
    }

    void PlayRandomSound()
    {
        if (sounds.Length > 0 && audioSource != null)
        {
            AudioClip randomClip = sounds[Random.Range(0, sounds.Length)];
            audioSource.pitch = Random.Range(1 - pitchChangeMult, 1 + pitchChangeMult);
            audioSource.volume = Random.Range(1 - volumeChangeMult, 1);
            audioSource.PlayOneShot(randomClip);
        }
        else if (sounds.Length == 0)
        {
            Debug.LogWarning("No sounds assigned in the sounds array!");
        }
    }
}
