using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private Vector3 WayPoint;
	public float speed;
	private Rigidbody rb;

	void Start(){
		// WayPoints = new List<Vector3>();
		// enemy = Instantiate(enemy,new Vector3(6,-4,0),Quaternion.identity);
		// WayPoints.Add(new Vector3(6,-2,0));	
		// WayPoints.Add(new Vector3(1,-2,0));	
		// WayPoints.Add(new Vector3(1,2,0));	
		// WayPoints.Add(new Vector3(-6,2,0));	
		// WayPoints.Add(new Vector3(6,4,0));
		// WayPoints.Add(new Vector3(6,0,0));	
		// WayPoints.Add(new Vector3(3,0,0));
		WayPoint = new Vector3 (5, 5, 0);
	    speed = 5.0f;
	}

	
    void Update(){
    	 float step = speed * Time.deltaTime;
    	  transform.Translate(Vector3.up * step);

    }

    // void makeMove(float step){
    // 		switch(n){
    // 		case 0:
    // 			enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(6,-2,0), step);
    // 			n++;
    // 			break;
    // 		case 1:
    // 			enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(1,-2,0), step);
    // 			n++;
    // 			break;
    // 		case 2:
    // 			enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(1,2,0), step);
    // 			n++;
    // 			break;
    // 		case 3:
    // 			enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(-6,2,0), step);
    // 			n++;
    // 			break;

    // 		case 4:
    // 			enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(6,4,0), step);
    // 			n++;
    // 			break;
    // 		case 5:
    // 			enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(6,0,0), step);
    // 			n++;
    // 			break;
    // 		case 6:
    // 			enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(3,0,0), step);
    // 			n++;
    // 			break;

    // 		default:
    //           break;
    //       }
    // 	}
}
