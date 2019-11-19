using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaypointManager : MonoBehaviour
{
    public List<GameObject> Waypoints = null;

    void Awake()
    {
        Waypoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Waypoint"));
        Waypoints = Waypoints.OrderBy(e => e.GetComponent<WaypointLogic>().ordinal).ToList();
        Waypoints.Reverse();
    }

    void Update()
    {
        
    }
}
