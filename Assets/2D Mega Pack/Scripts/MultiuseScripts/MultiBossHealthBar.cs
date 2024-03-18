using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiBossHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public MultiBossHealthBarHealthBar enemy1;
    public MultiBossHealthBarHealthBar enemy2;
    public Image healthBarFill;
  //  private float combinedHealth;
    private float maxCombinedHealth;

    void Start()
        {
            Debug.Log("MultiBossHealthBar Start method called");
            // Calculate the combined max health
            maxCombinedHealth = enemy1.maxHealth + enemy2.maxHealth;

            SetMaxHealth((int)maxCombinedHealth);
            // Update the health bar initially
           // UpdateHealthBar();
        }

        void Update()
        {
            // Calculate the combined health
           float combinedHealth = enemy1.currentHealth + enemy2.currentHealth;

            // Update the health bar
           SetHealth((int)combinedHealth);
        }

        void UpdateHealthBar(float combinedHealth)
        {
        // Set the health bar value
        SetHealth((int)combinedHealth);
        }
    
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }



}
