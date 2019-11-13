using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public List<GameObject> Waypoints;

    // Start is called before the first frame update
    void Start()
    {
        Waypoints.Reverse();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
