using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class WaypointLogic : MonoBehaviour
{
    public bool showWaypoints = false;
    public GameObject manager;
    public int ordinal = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Not sure if we need this
        manager = GameObject.Find("WaypointManager");

        // Set the order (ordinal) using the duplicate number in the Inspector
        string numInName = Regex.Replace(gameObject.name, "[^0-9]", "");
        if (numInName == "")
            numInName = "0";
        ordinal = int.Parse(numInName);
        //manager.GetComponent<WaypointManager>().Waypoints.Add(gameObject);

        // Numbered for debugging
        GetComponentInChildren<Text>().text = ordinal.ToString();
        if (showWaypoints)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponentInChildren<Canvas>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInChildren<Canvas>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
