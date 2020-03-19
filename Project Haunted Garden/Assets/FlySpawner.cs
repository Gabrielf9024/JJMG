using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    public GameObject Fly;
    public float spawnIntervals;
    public float radius;
    public int BugCount = 0;
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
        while (true)
        {
            Vector2 randomPoint = Random.insideUnitSphere * radius;
            if (BugCount < maxBombsAllowed)
            {
                GameObject newBomb = Instantiate(Fly, randomPoint, Quaternion.identity);
                newBomb.transform.parent = transform;
                ++BugCount;
            }
            yield return new WaitForSecondsRealtime(spawnIntervals);
        }
    }
}
