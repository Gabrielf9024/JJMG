using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("HealthUI")]
    public int maxHealth = 100;
    [SerializeField] int currentHealth;
    public Slider slider;
    public Text baseMoneyUI;
    public int myWorth;

    void Start()
    {
        baseMoneyUI = GameObject.Find("MoneyMidUI").GetComponent<Text>();
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
            GameObject.Find("GameManager").GetComponent<GameManager>().baseMoney += myWorth;
            baseMoneyUI.text = "$ " + GameObject.Find("GameManager").GetComponent<GameManager>().baseMoney.ToString();
            Destroy(gameObject);
        }
    }

    private void UpdateHealthUI()
    {
        slider.value = currentHealth;
    }
}
