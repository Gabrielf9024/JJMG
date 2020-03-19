using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject init;

    public void StartGame()
    {
        SceneManager.LoadScene(5);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LevelOne()
    {

        SceneManager.LoadScene(1);
    }
    public void LevelTwo()
    {

        SceneManager.LoadScene(2);
    }
    public void LevelThree()
    {

        SceneManager.LoadScene(3);
    }
    public void LevelFour()
    {

        SceneManager.LoadScene(4);
    }

    public void Quit() { Application.Quit(); }

}
