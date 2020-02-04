using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerEnemy : EnemyMovement
{
    // Start is called before the first frame update

    public float rotateSpeed;

    public float Minrange;
    public float Maxrange;
    public float stop;

    private Transform target;
    private Transform myself;
    private Rigidbody2D myBody;
    private Vector2 move;
    private Vector2 movementDirection;


    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 1.7f;
    void Awake()
    {
        myself = transform;
    }

    void Start()
    {
        latestDirectionChangeTime = 0f;
        target = GameObject.FindWithTag("Player").transform;
        myBody = GetComponent<Rigidbody2D>();
    }

    //// Update is called once per frame
    void Update()
    {
        // Attempt to make them move slower as they're damaged
        //GetComponent<EnemyMovement>().speed *= GetComponent<EnemyHealth>().currentHealth/GetComponent<EnemyHealth>().maxHealth;

        Vector3 OurDirection = target.position - myself.position;
        float angle = Mathf.Atan2(OurDirection.y, OurDirection.x) * Mathf.Rad2Deg -90f;
        OurDirection.Normalize();
        move = OurDirection;

        float distance = Vector3.Distance(myself.position, target.position);
        if (distance <= Maxrange && distance >= Minrange)
        {
            myBody.rotation = angle;
            //myBody.MovePosition((Vector2)myself.position + (move * speed * Time.deltaTime));
            MoveTo(target);
        }


        else if (distance <= Maxrange && distance > stop)
        {
            myBody.rotation = angle;
            //myBody.MovePosition((Vector2)myself.position + (move * speed * Time.deltaTime));
            MoveTo(target);
        }
        else
        {
            GetComponent<PathEnemy>().enabled = true;
            GetComponent<SeekerEnemy>().enabled = false;
        }
        //else
        //{
        //    if (Time.time - latestDirectionChangeTime > directionChangeTime)
        //    {
        //        latestDirectionChangeTime = Time.time;
        //        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        //    }
        //    myBody.MovePosition((Vector2)myself.position + (movementDirection * speed * Time.deltaTime));
        //}
        
    }

}
