using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public static SaveLevel Instance;
    public int LevelIndex;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void Reloadlevel()
    {
        SceneManager.LoadScene(LevelIndex);
    }
}
