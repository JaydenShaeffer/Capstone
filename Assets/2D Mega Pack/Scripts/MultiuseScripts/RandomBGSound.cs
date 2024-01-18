using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGSound : MonoBehaviour
{
    public AudioClip[] backgroundAudios;
    private AudioSource audioSource;
    public float adjustedVolune = 2.0f;
    public float notadjustedVolume = 1.0f;
    public AudioClip specificAudioClip; // Reference to the specific audio clip you want to adjust

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

            //volume for the specific audio clip
            if (randomClip == specificAudioClip/* the specific audio clip you want to adjust*/)
            {
                Debug.Log("Adjusting volume for specific clip");
                audioSource.volume = adjustedVolune;
            }
            else
            {
                // Set the default volume for other clips
                Debug.Log("Not adjusting volume for this clip");
                audioSource.volume = notadjustedVolume/* default volume */;
            }

            // Play the audio
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No background audio clips assigned.");
        }
    }
}
