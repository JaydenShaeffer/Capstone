using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] bossObjects;
    [SerializeField] private GameObject destroyHealthbar;
    [SerializeField] private GameObject healthBarObject;
   // [SerializeField] private Transform spawnPoint;

    private void SpawnBoss()
    {
        GameObject inactiveBoss = FindInactiveBoss();
        if (inactiveBoss != null)
        {
            inactiveBoss.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No inactive boss found.");
        }
    }

     private GameObject FindInactiveBoss()
    {
        foreach (GameObject bossObject in bossObjects)
        {
            if (!bossObject.activeInHierarchy)
            {
                return bossObject;
            }
        }
        return null; // No inactive boss found
    }

    private void ChangeHealthBar()
    {
        Destroy(destroyHealthbar);
    }
    
    private void ActivateHealthBar()
    {
        if (healthBarObject != null)
        {
            healthBarObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No health bar object assigned.");
        }
    }
}

