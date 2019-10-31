using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaypoints : MonoBehaviour
{
    public GameObject WayPoint;
    void Start()
    {
        Instantiate(WayPoint, new Vector3(4.5f, -1.5f, 0.0f), Quaternion.identity);
        Instantiate(WayPoint, new Vector3(-6.5f, -1.5f, 0.0f), Quaternion.identity);
        Instantiate(WayPoint, new Vector3(-6.5f, 0.5f, 0.0f), Quaternion.identity);
        Instantiate(WayPoint, new Vector3(6.5f, 0.5f, 0.0f), Quaternion.identity);
        Instantiate(WayPoint, new Vector3(6.5f, 2.5f, 0.0f), Quaternion.identity);
        Instantiate(WayPoint, new Vector3(-6.5f, 2.5f, 0.0f), Quaternion.identity);
        Instantiate(WayPoint, new Vector3(-6.5f, 4.0f, 0.0f), Quaternion.identity);
    }
}
