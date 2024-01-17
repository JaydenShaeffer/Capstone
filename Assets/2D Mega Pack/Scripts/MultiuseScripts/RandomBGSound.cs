using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGSound : MonoBehaviour
{
    public AudioClip[] backgroundAudios;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Check if there are any audio clips
        if (backgroundAudios.Length > 0)
        {
            // Choose a random audio clip
            int randomIndex = Random.Range(0, backgroundAudios.Length);
            AudioClip randomClip = backgroundAudios[randomIndex];

            // Set the chosen clip to the AudioSource
            audioSource.clip = randomClip;

            // Play the audio
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No background audio clips assigned.");
        }
    }
}
