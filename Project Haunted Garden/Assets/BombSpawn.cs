using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    public GameObject bomb;
    public float spawnIntervals;
    public float radius;
    public int bombCount = 0;
    public int maxBombsAllowed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBombs());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBombs()
    {
        while(true)
        {
            Vector2 randomPoint = Random.insideUnitSphere * radius;
            if (bombCount < maxBombsAllowed)
            {
                GameObject newBomb = Instantiate(bomb, randomPoint, Quaternion.identity);
                newBomb.transform.parent = transform;
                ++bombCount;
            }
            yield return new WaitForSecondsRealtime(spawnIntervals);
        }
    }
}
