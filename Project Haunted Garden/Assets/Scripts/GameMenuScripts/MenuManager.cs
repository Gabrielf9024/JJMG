using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
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
