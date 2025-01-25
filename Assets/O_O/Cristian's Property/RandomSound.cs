using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class RandomSound : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;
    [Range(0.1f, 0.5f)]
    public float volumeChangeMult = 0.2f;
    public float pitchChangeMult = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();   

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            source.clip = sounds[Random.Range(0, sounds.Length)]; 
            source.pitch = Random.Range(1 - pitchChangeMult, 1 + pitchChangeMult);
            source.volume = Random.Range(1 - volumeChangeMult, 1);
            source.PlayOneShot(source.clip);
        }
    }
}
*/

public class RandomSound : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;
    [Range(0.1f, 0.5f)] public float volumeChangeMult = 0.2f;
    public float pitchChangeMult = 0.2f;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Check if the ray hits a collider and if the object has the "Bubble" tag
            if (hit.collider != null && hit.collider.CompareTag("Bubble"))
            {
                PlayRandomSound();
            }
        }
    }

    void PlayRandomSound()
    {
        // Pick a random sound and modify pitch/volume
        if (sounds.Length > 0)
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.pitch = Random.Range(1 - pitchChangeMult, 1 + pitchChangeMult);
            source.volume = Random.Range(1 - volumeChangeMult, 1);
            source.PlayOneShot(source.clip);
        }
        else
        {
            Debug.LogWarning("No sounds assigned in the array!");
        }
    }
}