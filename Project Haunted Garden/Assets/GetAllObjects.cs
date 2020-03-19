using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllObjects : MonoBehaviour
{
    public GameObject[] EnemyObjects;
    public GameObject[] TowerObjects;
    public Transform PlayerPosition;
    public Inventory PlayerInventory;
    public int LevelIndex;
    public int BaseHealth;

    // Update is called once per frame
    void Update()
    {
        //GetAllEnemies();
       // GetPlayerPositionAndInventory();
       // GetWaveInformation();
    }
    public void GetAllEnemies()
    {
        EnemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        if (EnemyObjects != null)
        {
            GlobalControl.Instance.EnemyObjects = EnemyObjects;
        }
    }
    public void GetPlayerPositionAndInventory()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        GlobalControl.Instance.PlayerPosition = PlayerPosition;
        GlobalControl.Instance.PlayerInventory = PlayerInventory;
    }
    public void GetWaveInformation()
    {
        LevelIndex = GameObject.FindGameObjectWithTag("LevelSpawner").GetComponent<LevelManager>().levelIndex;
        GlobalControl.Instance.LevelIndex = LevelIndex;
    }
    public void GetAllTowers()
    {
        TowerObjects = GameObject.FindGameObjectsWithTag("Tower");
        GlobalControl.Instance.TowerObjects = TowerObjects;
    }
}
