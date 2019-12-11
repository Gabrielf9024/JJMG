using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public delegate void ChangeEvent(bool alive);
    public static event ChangeEvent deathEvent;
    public bool alive = true;


    [Header("HealthUI")]
    public int maxHealth = 100;
    public float currentHealth;
    public Slider slider;
    public Text baseMoneyUI;
    public int myWorth;

    void Start()
    {
        if (deathEvent != null)
            deathEvent(false);

        baseMoneyUI = GameObject.Find("MoneyMidUI").GetComponent<Text>();
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        UpdateHealthUI();

    }

    void Update()
    {
        
    }

    public void damage( float d )
    {
        currentHealth -= d;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthUI();

        if (currentHealth == 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().baseMoney += myWorth;
            baseMoneyUI.text = "$ " + GameObject.Find("GameManager").GetComponent<GameManager>().baseMoney.ToString();
            if (deathEvent != null)
                deathEvent(false);
            Destroy(gameObject);
        }
    }

    private void UpdateHealthUI()
    {
        slider.value = currentHealth;
    }
}
