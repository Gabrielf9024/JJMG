    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Spawn : MonoBehaviour
{

    public int ordinal = 0;

    [System.Serializable]
    public class EnemyEntry
    {
        public string Name = "Enemy";
        public GameObject enemy;
        public int groupSize;
        public float speed;
        public int health;
        public float delayWithinGroup = 0.2f;
        public float delayAfterPrevGroup = 1.0f;
   }
    public EnemyEntry[] enemyGroupList;
    public int groupIndex = 0;
    public EnemyEntry currentGroup;
    public bool doneSpawning = false;
    private bool waiting = false;

    private void Awake()
    {
        // Set the order (ordinal) using the number found in the GameObject's name
        string numInName = Regex.Replace(gameObject.name, "[^0-9]", "");
        if (numInName == "")
            numInName = "0";
        ordinal = int.Parse(numInName);


        currentGroup = enemyGroupList[groupIndex];
    }
    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        foreach(EnemyEntry e in enemyGroupList)
        {
            currentGroup = enemyGroupList[groupIndex];

            // If we're not waiting for a group to finish spawning, spawn the next group
            if( !waiting )
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().currentWave = groupIndex; ;
                yield return StartCoroutine(SpawnGroup(e));
                ++groupIndex;
            }
        }
        doneSpawning = true;
    }

    IEnumerator SpawnGroup( EnemyEntry ee )
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(ee.delayAfterPrevGroup);
        // Spawn a group of identical enemies, using delayWithinGroup to space them out
        for ( int i = 0; i < ee.groupSize; ++i)
        {
            GameObject newEnemy = Instantiate(ee.enemy, transform.position, transform.rotation);
            newEnemy.GetComponent<EnemyMovement>().SetSpeed(ee.speed);
            if(ee.health == 0)
            {
                newEnemy.GetComponent<EnemyHealth>().maxHealth = 100;
            }
            else
                newEnemy.GetComponent<EnemyHealth>().maxHealth = ee.health;

            yield return new WaitForSeconds(ee.delayWithinGroup);
        }
        waiting = false;
    }
}
