using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float rotateSpeed;

    public float Minrange;
    public float Maxrange;
    public float stop;

    private Transform target;
    private Transform myself;
    private Rigidbody2D myBody;
    private Vector2 move;

    void Awake()
    {
        myself = transform;
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        myBody = GetComponent<Rigidbody2D>();
    }

    //// Update is called once per frame
    void Update()
    {
        Vector3 OurDirection = target.position - myself.position;
        float angle = Mathf.Atan2(OurDirection.y, OurDirection.x) * Mathf.Rad2Deg;
        OurDirection.Normalize();
        move = OurDirection;

        float distance = Vector3.Distance(myself.position, target.position);
        if (distance <= Maxrange && distance >= Minrange)
        {
            myBody.rotation = angle;
            myBody.MovePosition((Vector2)myself.position + (move * speed * Time.deltaTime));
        }


        else if (distance <= Maxrange && distance > stop)
        {
            myBody.rotation = angle;
            myBody.MovePosition((Vector2)myself.position + (move * speed * Time.deltaTime));
        }
        else if (distance <= stop)
        {
            return;
        }
    }
}
