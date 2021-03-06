﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool paused = false;
    public bool lost = false;
    private GameObject pauseMenu;
    private GameObject loserText;
    private GameObject Store;

    public int baseHealth = 100;
    public Text baseHealthUI;
    public Text baseMoneyUI;
    public int baseMoney;

    private void Awake()
    {
        loserText = GameObject.Find("Loser");
        pauseMenu = GameObject.Find("Quit");
        baseHealthUI = GameObject.Find("HealthLeftUI").GetComponent<Text>();
        baseMoneyUI = GameObject.Find("MoneyMidUI").GetComponent<Text>();
        Store = GameObject.Find("StorePanel");
    }

    private void Start()
    {
        Store.SetActive(false);
        UpdateUI();
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Escape)){
            paused = !paused;
        }

        if( paused )
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            if( !lost )
                Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }

        if (lost)
        {
            loserText.SetActive(true);
        }
        else
        {
            loserText.SetActive(false);
        }
        baseMoneyUI.text = "$ " + baseMoney.ToString();
    }

    public void Quit() { Application.Quit(); }

    public void EndGame()
    {
        lost = true;
        Time.timeScale = 0;
        loserText.SetActive(true);
    }

    public void ClearScreen()
    {
        GameObject[] bullets;
        bullets = GameObject.FindGameObjectsWithTag("Projectile");

        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }

    public void UpdateUI()
    {
        baseMoneyUI.text = baseMoney.ToString();
        baseHealthUI.text = baseHealth.ToString();
        if (baseHealth == 0)
            EndGame();
        
    }

}
