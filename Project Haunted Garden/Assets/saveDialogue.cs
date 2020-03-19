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
}
