using UnityEngine;

public class VideoVolumeController : MonoBehaviour
{
    private AudioSource audioSource;
    [Header("Trav Voice Volume")]
    [SerializeField] private AudioClip spawnSound;
    float adjustedVolume = 5.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = spawnSound; // Set the audio clip
        audioSource.loop = true; // Set the loop property to true
        audioSource.volume = adjustedVolume; // Set the volume
        audioSource.Play(); // Start playing the audio
    }
}
