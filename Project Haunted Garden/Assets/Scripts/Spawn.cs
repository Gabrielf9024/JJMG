    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    /*
    public GameObject[] enemies;
    public int[] groupSizes;

    private Dictionary<GameObject, int> dict;

    */
    [System.Serializable]
    public class EnemyEntry
    {
        public string Name = "Enemy";
        public GameObject enemy;
        public int groupSize;
        public float speed;
        public float delayWithinGroup = 0.2f;
        public float delayAfterPrevGroup = 1.0f;
   }
    public EnemyEntry[] enemyGroupList;

    public bool doneSpawning = false;
    private bool waiting = false;


    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        foreach(EnemyEntry e in enemyGroupList)
        {
            if( !waiting )
            {
                yield return StartCoroutine(SpawnGroup(e));
            }
        }
        doneSpawning = true;
    }

    IEnumerator SpawnGroup( EnemyEntry ee )
    {
        waiting = true;
        yield return new WaitForSeconds(ee.delayAfterPrevGroup);
        for ( int i = 0; i < ee.groupSize; ++i)
        {
            GameObject newEnemy = Instantiate(ee.enemy, transform.position, transform.rotation);
            newEnemy.GetComponent<EnemyMovement>().SetSpeed(ee.speed);

            yield return new WaitForSeconds(ee.delayWithinGroup);
        }
        waiting = false;
    }
}
