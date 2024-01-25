using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ItemCollector : MonoBehaviour
{
    public Animator playerAnimator;
    public string nextLevelName;
    public bool secret = false;
    public string secretLevelName;
    [SerializeField] private AudioClip tpSound;

    [SerializeField] public static int score;

    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        if (score >= 1000)
        {
            LevelManager.secretStuck = true;
            secret = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Z"))
        {
            Destroy(collision.gameObject);
            score += 100;
            scoreText.text = "Score: " + score;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NextLevel"))
        {
            // Play transition animation
            playerAnimator.SetTrigger("End");
            SoundManager.instance.PlaySound(tpSound);

            

            if (secret = true)
            {
                if (score <= 900 && LevelManager.secretStuck == false)
                {
                    Debug.Log("I am addicted - jeff");
                    // Invoke the LoadNextLevel function after the animation duration
                    Invoke("LoadNextLevel", GetAnimationDuration("Player_End")); 
                    return;
                }   

                Debug.Log("SecretLevel");
                Invoke("secretNextLevel", GetAnimationDuration("Player_End"));
            }
            
           
             // Set the animation state in PlayerMovement script
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.SetAnimationState(true);
                }
                
            }
        }
    }

    void LoadNextLevel()
    {
        // Load the next level
        SceneManager.LoadScene(nextLevelName);
    }

    void secretNextLevel()
    {
        // Load the next level
        SceneManager.LoadScene(secretLevelName);
    }

    float GetAnimationDuration(string animationClipName)
    {
        AnimationClip[] clips = playerAnimator.runtimeAnimatorController.animationClips;
        foreach (var clip in clips)
        {
            if (clip.name == animationClipName)
            {
                return clip.length;
            }
        }
        return 0f; // Default to 0 if animation not found
    }
}
