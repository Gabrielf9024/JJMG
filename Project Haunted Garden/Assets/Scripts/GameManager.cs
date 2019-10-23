using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool paused;
    public GameObject pauseMenu;


    private void Awake()
    {
        pauseMenu = GameObject.Find("Quit");
    }
    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.Escape)){
            paused = !paused;
        }

        if( paused )
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }



        if( Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Prototype Scene v1");
        }


    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EndGame()
    {
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

}
