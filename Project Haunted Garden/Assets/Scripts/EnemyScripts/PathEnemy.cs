using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEnemy : MonoBehaviour
{
    public Transform nextWaypoint;
    public int currentWPindex = 0;

    public List<GameObject> waypoints;
    private Vector3 direction;
    private Quaternion lookRotation;

    void Awake()
    {
        waypoints = GameObject.Find("WaypointManager").GetComponent<WaypointManager>().Waypoints;
    }
    private void Start()
    {
        currentWPindex = 0;
        nextWaypoint = waypoints[currentWPindex].transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Find the direction Vector3 between the next wp and you
        direction = (nextWaypoint.position - transform.position).normalized;
        // Face that waypoint
        lookRotation = Quaternion.LookRotation(direction);

        GetComponent<EnemyMovement>().MoveTo(nextWaypoint);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Waypoint"))
        {
            ++currentWPindex;
            nextWaypoint = waypoints[currentWPindex].transform;
        }
    }
}
