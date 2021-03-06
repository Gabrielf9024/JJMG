﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject[] spawners;
    public GameObject[] enemies;
    public bool levelDone = false;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth.deathEvent += OnEnemyDeath;
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        levelDone = CheckIfLevelDone();

    }

    void OnEnemyDeath( bool alive )
    {
        //levelDone = CheckIfLevelDone();
    }

    public bool CheckIfLevelDone()
    {
        enemies = null;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            foreach (GameObject s in spawners){
                if (!s.GetComponent<Spawn>().doneSpawning)
                    return false;
                return true;
            }
        }
        return false;

    }
}
