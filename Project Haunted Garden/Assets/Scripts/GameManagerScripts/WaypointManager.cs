using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaypointManager : MonoBehaviour
{
    public List<GameObject> Waypoints = null;

    void Awake()
    {
        // Get the list of waypoints and put them in order, so the enemies have a list of waypoints to follow
        Waypoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Waypoint"));
        Waypoints = Waypoints.OrderBy(e => e.GetComponent<WaypointLogic>().ordinal).ToList();
        //Waypoints.Reverse();
    }

    void Update()
    {
        
    }
}
