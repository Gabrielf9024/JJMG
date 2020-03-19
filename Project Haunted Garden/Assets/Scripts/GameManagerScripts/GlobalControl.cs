using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public GameObject[] EnemyObjects;
    public GameObject[] TowerObjects;
    public Transform PlayerPosition;
    public Inventory PlayerInventory;
    public int LevelIndex;
    public string WaveName;
    public int BaseHealth;

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
