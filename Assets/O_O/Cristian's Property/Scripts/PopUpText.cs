using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using TMPro;

/*public class PopUpText : MonoBehaviour
{
    [SerializeField] private float startingVelocity = 300f; // Adjusted for smoother motion
    [SerializeField] private float velocityDecayRate = 50f;
    [SerializeField] private float timeBeforeFadeStarts = 0.5f;
    [SerializeField] private float fadeSpeed = 2f;

    private TextMeshProUGUI clickAmountText;
    private Vector2 currentVelocity;
    private Color startColor;
    private float timer;
    private float textAlpha;

    private void OnEnable()
    {
        // Get the TextMeshPro component and reset its color
        clickAmountText = GetComponent<TextMeshProUGUI>();
        startColor = clickAmountText.color;
        startColor.a = 1f;
        clickAmountText.color = startColor;

        timer = 0f;
        textAlpha = 1f;
    }

    public static PopUpText Create(int amount, GameObject popupTextPrefab, Canvas popupCanvas)
    {
    // Spawn the popup text object on the provided canvas
    GameObject popupObj = Instantiate(popupTextPrefab, popupCanvas.transform);
    popupObj.transform.position = popupCanvas.transform.position;

    PopUpText bubblePopup = popupObj.GetComponent<PopUpText>();
    bubblePopup.Init(amount);

    return bubblePopup;
    }
//?

    public void Init(float amount)
    {
        // Set the text content and initialize the velocity
        clickAmountText.text = "+" + amount.ToString("0");

        float randomX = Random.Range(-150f, 150f); // Random horizontal movement
        currentVelocity = new Vector2(randomX, startingVelocity);
    }

    private void Update()
    {
        // Update position with velocity
        currentVelocity.y -= Time.deltaTime * velocityDecayRate; // Decaying vertical velocity
        transform.Translate(currentVelocity * Time.deltaTime);

        // Handle fading
        timer += Time.deltaTime;
        if (timer > timeBeforeFadeStarts)
        {
            textAlpha -= Time.deltaTime * fadeSpeed;
            startColor.a = Mathf.Clamp01(textAlpha); // Ensure alpha stays in range
            clickAmountText.color = startColor;

            // Return to pool or destroy when fully faded
            if (textAlpha <= 0f)
            {
                Destroy(gameObject); // Replace with pool return method if using pooling
            }
        }
    }
}
*/

public class PopUpText : MonoBehaviour
{
    [SerializeField] private float startingVelocity = 300f;
    [SerializeField] private float velocityDecayRate = 50f;
    [SerializeField] private float timeBeforeFadeStarts = 0.5f;
    [SerializeField] private float fadeSpeed = 2f;

    private TextMeshProUGUI clickAmountText;
    private Vector2 currentVelocity;
    private Color startColor;
    private float timer;
    private float textAlpha;

    private void OnEnable()
    {
        clickAmountText = GetComponent<TextMeshProUGUI>();  // Get the TextMeshPro component from the instantiated prefab
        startColor = clickAmountText.color;
        startColor.a = 1f;
        clickAmountText.color = startColor;

        timer = 0f;
        textAlpha = 1f;
    }

    public static PopUpText Create(int amount, GameObject popupTextPrefab, Canvas popupCanvas)
    {
        // Spawn the popup text object on the provided canvas
        GameObject popupObj = Instantiate(popupTextPrefab, popupCanvas.transform);
        popupObj.transform.position = popupCanvas.transform.position;

        PopUpText bubblePopup = popupObj.GetComponent<PopUpText>();
        bubblePopup.Init(amount);  // Call Init to set the text of the prefab with the correct amount

        return bubblePopup;
    }

    // Init method to update the text of the popup
    public void Init(int amount)
    {
        // Dynamically update the text to show the current bubblesPerClick amount
        clickAmountText.text = "+" + amount.ToString("0");

        // Apply random movement
        float randomX = Random.Range(-150f, 150f);  // Apply random horizontal movement
        currentVelocity = new Vector2(randomX, startingVelocity);
    }

    private void Update()
    {
        // Apply vertical movement
        currentVelocity.y -= Time.deltaTime * velocityDecayRate;
        transform.Translate(currentVelocity * Time.deltaTime);

        // Handle fading out of the text
        timer += Time.deltaTime;
        if (timer > timeBeforeFadeStarts)
        {
            textAlpha -= Time.deltaTime * fadeSpeed;
            startColor.a = Mathf.Clamp01(textAlpha);  // Clamp alpha between 0 and 1
            clickAmountText.color = startColor;

            // Destroy the object when fully faded
            if (textAlpha <= 0f)
            {
                Destroy(gameObject);  // Or return it to a pool if using object pooling
            }
        }
    }
}



