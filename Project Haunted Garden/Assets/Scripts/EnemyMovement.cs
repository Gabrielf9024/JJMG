using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;

	void Start()
    {
    }
    void Update()
    {
    }

    public void MoveTo( Transform destination )
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination.position, step);

    }


}
