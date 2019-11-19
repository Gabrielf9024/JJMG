using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class WaypointLogic : MonoBehaviour
{
    public GameObject manager;
    public int ordinal = 0;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("WaypointManager");
        //        int existing = GameObject.FindGameObjectsWithTag("Waypoint").Length;
        string numInName = Regex.Replace(gameObject.name, "[^0-9]", "");
        if (numInName == "")
            numInName = "0";
        ordinal = int.Parse(numInName);
        //manager.GetComponent<WaypointManager>().Waypoints.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
