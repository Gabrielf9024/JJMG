using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    public TextMeshProUGUI baseHealthUI;
    public TextMeshProUGUI waveUI;
    public LevelManager lm;

    public int currentWave = 0;
    public int baseMoney;

    private void Awake()
    {
        //loserText = GameObject.Find("Loser");
        //winnerText = GameObject.Find("Winner");
        //pauseMenu = GameObject.Find("Quit");
        //baseHealthUI.text = GameObject.Find("Health").GetComponent<Text>().text;
        //waveUI.text = GameObject.Find("Wave").GetComponent<Text>().text;
        //lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        //Store = GameObject.Find("StorePanel");
    }

    private void Start()
    {
        //Store.SetActive(false);
        UpdateUI();
        SaveLevel.Instance.LevelIndex++;
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Escape)){
            paused = !paused;
        }

        if( paused )
        {
            Time.timeScale = 0;
            //pauseMenu.SetActive(true);
        }
        else
        {
            if( !lost )
                Time.timeScale = 1;
            //pauseMenu.SetActive(false);
        }

        if (lost)
        {
            //loserText.SetActive(true);
        }
        else
        {
            //loserText.SetActive(false);
        }
        UpdateUI();
    }

    public void Quit() { Application.Quit(); }

    public void LostGame()
    {
        lost = true;
        //Time.timeScale = 0;
        SceneManager.LoadScene(7);
    }

    public void WonGame()
    {
        //waveUI.GetComponent<Text>().enabled = false;
        //winnerText.GetComponent<Text>().enabled = true;
        SceneManager.LoadScene(5);
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
        baseHealthUI.text = "Health: "+ baseHealth.ToString();
        if (lm.levelIndex > 0)
            waveUI.text = "Level " + lm.levelIndex; // + ": " + lm.Levels[lm.levelIndex-1].GetComponent<Spawn>().currentGroup.Name;
        if (lm.readyForNextLevel)
            waveUI.text = "Space to Start " + (lm.levelIndex+1);
        if (baseHealth == 0)
            LostGame();
        
    }

}
