using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecretLoadingScreenController : MonoBehaviour
{
    public Slider loadingSlider;
    public float loadingTime = 3f;


    private void Start()
    {
        loadingSlider.value = 0f;
        InvokeRepeating("UpdateLoadingBar", 0f, loadingTime / 100);
        Invoke("LoadNextLevel", loadingTime);
    }

    private void UpdateLoadingBar()
    {
        loadingSlider.value += 1f;
    }

    private void LoadNextLevel()
    {
        string nextLevel = SecretLevelManager.instance.GetNextLevel();

        if (nextLevel != null)
        {
            SceneManager.LoadScene(nextLevel); // Load the next level directly
        }
        else
        {
            Debug.Log("Game completed!");
            // Handle game completion logic
        }
    }
    private void RetryGame()
    {
        ItemCollector.score = 0;
        Debug.Log("Log that - jeff");
        LoadingImageChanger.levelCount = 1;
        SecretLevelManager.instance.ResetLevelIndex();
        LevelManager.instance.ResetLevelIndex();
        SceneManager.LoadScene("LoadingScreen"); // Load the first level again
    }

}

