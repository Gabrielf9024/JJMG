using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveDialogue : MonoBehaviour
{
    public static saveDialogue Instance;
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
    public void SelectedLevel(int level)
    {
        if(level == 1)
        {
            Instance.LevelIndex = 4;
        }
        else if (level == 2)
        {
            Instance.LevelIndex = 6;
        }
        else if (level == 3)
        {
            Instance.LevelIndex = 8;
        }
        else if (level == 4)
        {
            Instance.LevelIndex = 10;
        }
        else if (level == 0)
        {
            Instance.LevelIndex = 0;
        }
    }
}
