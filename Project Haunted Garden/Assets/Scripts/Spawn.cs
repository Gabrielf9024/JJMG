using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<Dictionary<GameObject, int>> SpawnList;
    public float delayInterval = 1.0f;
    public int amountToSpawn = 1;

    public GameObject pathEnemy;
    public GameObject flyEnemy;

    void OnEnable()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartSpawning()
    {
        Instantiate(pathEnemy);
        yield return new WaitForSeconds(delayInterval);
    }
}
