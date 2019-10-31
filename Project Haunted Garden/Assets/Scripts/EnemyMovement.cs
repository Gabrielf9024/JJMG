using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private List<Vector3> WayPoints;
	public float speed;
    private int index;

	void Start(){
        WayPoints = new List<Vector3>();
        WayPoints.Add(new Vector3(4.5f, -1.5f, 0.0f));
        WayPoints.Add(new Vector3(-6.5f, -1.5f, 0.0f));
        WayPoints.Add(new Vector3(-6.5f, 0.5f, 0.0f));
        WayPoints.Add(new Vector3(6.5f, 0.5f, 0.0f));
        WayPoints.Add(new Vector3(6.5f, 2.5f, 0.0f));
        WayPoints.Add(new Vector3(-6.5f, 2.5f, 0.0f));
        WayPoints.Add(new Vector3(-6.5f, 4.0f, 0.0f));
        speed = 5f;
        index = 0;
    }

	
    void Update(){
        if (index < WayPoints.Count)
            MoveTo();
    }
    void MoveTo(){
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,WayPoints[index],step);
        if (Vector3.Distance(transform.position, WayPoints[index]) < 0.001f){
            index++;
        }
    }
}
