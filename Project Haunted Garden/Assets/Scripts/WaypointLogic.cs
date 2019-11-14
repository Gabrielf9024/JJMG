using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointLogic : MonoBehaviour
{
    public GameObject manager;

    // Start is called before the first frame update
    void Awake()
    {
        manager = GameObject.Find("WaypointManager");

        manager.GetComponent<WaypointManager>().Waypoints.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
