using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
/*
public class NewClickScript : MonoBehaviour
{
    public Wallet wallet; // Reference to WalletManager
    public int bubblesPerClick = 1; // Amount of bubbles added per click
    public AudioClip[] sounds; // Array of random sounds to play
    private AudioSource audioSource; // Reference to the AudioSource
    [Range(0.1f, 0.5f)] public float volumeChangeMult = 0.2f;
    public float pitchChangeMult = 0.2f;
    public GameObject bubbleClickPrefab;
    public float maxRadius = 10.1f;
    public GameObject background; // Reference to background object

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
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectPos = new Vector3(objectPos.x,objectPos.y,0.0f);
            Instantiate(bubbleClickPrefab,objectPos,Quaternion.identity);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            // If the ray hits something
            if (hit.collider != null)
            {
                // Check if the clicked object has a BubbleFloat component
                BubbleFloat bubbleFloat = hit.collider.gameObject.GetComponent<BubbleFloat>();
                if (bubbleFloat != null)
                {
                    // Play a random sound
                    PlayRandomSound();
                    
                     // Show popup text
                    PopUpText.Create(bubblesPerClick, bubbleFloat.PopupTextPrefab, bubbleFloat.PopupCanvas);

                    
                    // Perform the bubble click action
                    bubbleFloat.Clicked();
                    wallet.AddBubbles(bubblesPerClick);

                    

                    // Scale the background if assigned
                    //if (background != null)
                    //{
                     //   background.transform
                     //       .DOScale(background.transform.localScale * 1.05f, 0.05f)
                       //     .OnComplete(() =>
                         //       background.transform.DOScale(background.transform.localScale / 1.05f, 0.05f));
                   // }
                }
            }
        }
    }

    public void PlayRandomSound()
    {
        if (sounds.Length > 0)
        {
            // Ensure AudioSource is available
            if (audioSource == null)
            {
                Debug.LogError("AudioSource is missing on this object!");
                return;
            }

            // Choose a random sound from the array
            AudioClip selectedClip = sounds[Random.Range(0, sounds.Length)];
            if (selectedClip == null)
            {
                Debug.LogError("Selected sound clip is null!");
                return;
            }

            // Log the selected sound and its properties
            Debug.Log($"Playing sound: {selectedClip.name}");

            // Apply pitch and volume adjustments
            float randomPitch = Random.Range(1 - pitchChangeMult, 1 + pitchChangeMult);
            float randomVolume = Random.Range(1 - volumeChangeMult, 1);

            audioSource.pitch = randomPitch;
            audioSource.volume = randomVolume;

            // Play the selected sound
            audioSource.PlayOneShot(selectedClip);
        }
        else
        {
            Debug.LogWarning("No sounds assigned in the array!");
        }
    }




    public void ClickBubbleAdd()
    {
        wallet.AddBubbles(bubblesPerClick);
    }
    public void RadiusUpgrade()
    {
        maxRadius = maxRadius * 1.2f;
    }
}
*/


public class NewClickScript : MonoBehaviour
{
    public Wallet wallet; // Reference to WalletManager
    public int bubblesPerClick = 1; // Amount of bubbles added per click
    public AudioClip[] sounds; // Array of random sounds to play
    private AudioSource audioSource; // Reference to the AudioSource
    [Range(0.1f, 0.5f)] public float volumeChangeMult = 0.2f;
    public float pitchChangeMult = 0.2f;
    public GameObject bubbleClickPrefab;
    public float maxRadius = 10.1f;
    public GameObject background; // Reference to background object
    public Button upgradeButton; // Reference to the upgrade button
    public int upgradeCost = 10; // Initial upgrade cost
    private int upgradeLevel = 0; // Tracks the upgrade level

    void Start()
    {
        // Ensure an AudioSource component is attached and assigned
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Debug.Log("AudioSource component was missing and has been added dynamically.");
        }

        // Get the WalletManager reference
        if (wallet == null)
        {
            wallet = Wallet.instance;
            if (wallet == null)
            {
                Debug.LogError("WalletManager not found in the scene!");
                return;
            }
        }

        // Bind the Upgrade Button
        if (upgradeButton != null)
        {
            upgradeButton.onClick.AddListener(UpgradeBubblesPerClick);
        }

        // Update the button text at the start
        UpdateUpgradeButtonText();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectPos = new Vector3(objectPos.x, objectPos.y, 0.0f);

            Instantiate(bubbleClickPrefab, objectPos, Quaternion.identity);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            // If the ray hits something
            if (hit.collider != null)
            {
                Debug.Log("Amount: " + bubblesPerClick);
                // Check if the clicked object has a BubbleFloat component
                BubbleFloat bubbleFloat = hit.collider.gameObject.GetComponent<BubbleFloat>();
                if (bubbleFloat != null)
                {
                    // Dynamically display the updated `bubblesPerClick`

                    GameObject popupObj = Instantiate(bubbleFloat.PopupTextPrefab, bubbleFloat.PopupCanvas.transform);
                    popupObj.transform.position = bubbleFloat.PopupCanvas.transform.position;

                    PopUpText bubblePopup = popupObj.GetComponent<PopUpText>();
                    bubblePopup.amount = bubblesPerClick;

                    Debug.Log("Amount: " + bubblesPerClick);

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
        if (audioSource != null && sounds.Length > 0)
        {
            audioSource.clip = sounds[Random.Range(0, sounds.Length)];
            audioSource.pitch = Random.Range(1 - pitchChangeMult, 1 + pitchChangeMult);
            audioSource.volume = Random.Range(1 - volumeChangeMult, 1);
            audioSource.PlayOneShot(audioSource.clip);
        }
        else
        {
            Debug.LogWarning("No AudioSource or sounds assigned!");
        }
    }

    void UpgradeBubblesPerClick()
    {
        if (wallet.bubbles >= upgradeCost)
        {
            wallet.SubBubbles(upgradeCost);
            bubblesPerClick += 1; // Increase bubbles per click
            upgradeLevel++;
            upgradeCost += upgradeLevel * 10; // Increase the cost exponentially
            UpdateUpgradeButtonText();
        }
        else
        {
            Debug.Log("Not enough bubbles to upgrade!");
        }
    }

    void UpdateUpgradeButtonText()
    {
        if (upgradeButton != null)
        {
            Text buttonText = upgradeButton.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                buttonText.text = $"Upgrade Click (+1) - Cost: {upgradeCost}";
            }
        }
    }

    public void UpgradeClickPower()
    {
        bubblesPerClick++; // Increment bubbles per click
        Debug.Log("Bubbles per click increased to: " + bubblesPerClick);
    }

    public void ClickBubbleAdd()
    {
        wallet.AddBubbles(bubblesPerClick);
    }
}


