using System.Collections;
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
    private GameObject winnerText;
    private GameObject Store;

    public int baseHealth = 100;
    public Text baseHealthUI;
    public Text baseMoneyUI;
    public Text waveUI;
    public LevelManager lm;

    public int currentWave = 0;
    public int baseMoney;

    private void Awake()
    {
        loserText = GameObject.Find("Loser");
        winnerText = GameObject.Find("Winner");
        pauseMenu = GameObject.Find("Quit");
        baseHealthUI = GameObject.Find("HealthLeftUI").GetComponent<Text>();
        baseMoneyUI = GameObject.Find("MoneyMidUI").GetComponent<Text>();
        waveUI = GameObject.Find("WaveUI").GetComponent<Text>();
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        Store = GameObject.Find("StorePanel");

        winnerText.GetComponent<Text>().enabled = false;
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
        UpdateUI();
    }

    public void Quit() { Application.Quit(); }

    public void LostGame()
    {
        lost = true;
        Time.timeScale = 0;
        loserText.SetActive(true);
    }

    public void WonGame()
    {
        waveUI.GetComponent<Text>().enabled = false;
        winnerText.GetComponent<Text>().enabled = true;
        Time.timeScale = 0;
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
        baseMoneyUI.text = "$ " + baseMoney.ToString();
        baseHealthUI.text = "Health: "+ baseHealth.ToString();
        if(lm.levelIndex > 0)
            waveUI.text = "Level " + lm.levelIndex + ": " + lm.Levels[lm.levelIndex-1].GetComponent<Spawn>().currentGroup.Name;
        if (lm.readyForNextLevel)
            waveUI.text = "Press Space to Start Level " + (lm.levelIndex+1);
        if (baseHealth == 0)
            LostGame();
        
    }

}
