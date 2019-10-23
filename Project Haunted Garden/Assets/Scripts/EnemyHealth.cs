using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("HealthUI")]
    public int maxHealth = 10;
    [SerializeField] int currentHealth;
    public Slider slider;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();

    }

    void Update()
    {
        
    }

    public void damage( int d )
    {
        currentHealth -= d;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthUI();

        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateHealthUI()
    {
        slider.value = currentHealth;
    }
}
