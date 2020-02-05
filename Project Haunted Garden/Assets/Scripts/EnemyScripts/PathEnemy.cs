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
    private Rigidbody2D myBody;


    void Awake()
    {
        waypoints = GameObject.Find("WaypointManager").GetComponent<WaypointManager>().Waypoints;
        myBody = GetComponent<Rigidbody2D>();
        nextWaypoint = waypoints[currentWPindex].transform;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {

/*

        // Find the direction Vector3 between the next wp and you
        direction = (nextWaypoint.position - transform.position).normalized;
        // Face that waypoint
        transform.Rotate(direction);
*/
        GetComponent<EnemyMovement>().MoveTo(nextWaypoint);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Waypoint"))
        {
            ++currentWPindex;
            nextWaypoint = waypoints[currentWPindex].transform;

            FaceWaypoint();
        }
    }
    void OnEnable()
    {
        nextWaypoint = waypoints[currentWPindex].transform;

        FaceWaypoint();
    }

    private void FaceWaypoint()
    {
        Vector3 OurDirection = nextWaypoint.position - transform.position;
        float angle = Mathf.Atan2(OurDirection.y, OurDirection.x) * Mathf.Rad2Deg - 90f;
        myBody.rotation = angle;
    }
}
