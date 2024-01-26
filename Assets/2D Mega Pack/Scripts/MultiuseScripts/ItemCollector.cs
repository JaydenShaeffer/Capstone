using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ItemCollector : MonoBehaviour
{
    public static bool isPoweredUp = false; // Variable to track power-up state

    public Sprite originalSprite;
    public Sprite poweredUpSprite;
    public SpriteRenderer projectile;
    public Animator playerAnimator;
    public string nextLevelName;
    public bool secret = false;
    public string secretLevelName;

    [Header("Z Sound")]
    [SerializeField] private AudioClip zSound;
// TEST [SerializeField] private AudioClip poweredUpAttackSound;
   


    [Header("Powerup Sound")]
    [SerializeField] private AudioClip powerupSound;

    [SerializeField] private AudioClip tpSound;

    [SerializeField] public static int score;

    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        projectile.GetComponent<SpriteRenderer>().sprite = originalSprite;
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
    {  if(Projectile.damage <= 25)
        {
            if (collision.gameObject.CompareTag("Powerup"))
            {
                Destroy(collision.gameObject);
                Projectile.damage = Projectile.damage * 2;
                Debug.Log($"Projectile damage is now: {Projectile.damage}");
                projectile.GetComponent<SpriteRenderer>().sprite = poweredUpSprite;
                SoundManager.instance.PlaySound(powerupSound);
                isPoweredUp = true;

                StartCoroutine (StopDamagePowerup());
            }  
        }


        if (collision.gameObject.CompareTag("Z"))
        {
            SoundManager.instance.PlaySound(zSound);
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

    IEnumerator StopDamagePowerup()
    {
        yield return new WaitForSeconds (10.0f);
        Projectile.damage = Projectile.damage / 2;
        isPoweredUp = false;
        Debug.Log($"Projectile damage is now: {Projectile.damage}");
        projectile.GetComponent<SpriteRenderer>().sprite = originalSprite;
    }
}
