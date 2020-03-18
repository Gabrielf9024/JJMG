using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBug : MonoBehaviour
{
    [Header("Movement Variables")]
    public float speed;
    public GameObject boxBorder;

    [Header("Spot Plant Variables")]
    public float FindingRadius;
    public float StopDistance;

    [Header("Attack Damage")]
    public float AttackDmg;


    private float Sspeed;
    private float StopSpeed = 0f;
    private bool stop = false;
    private bool atPlant = false;
    private Vector3 newPosition;
    private Vector2 move;
    private Rigidbody2D myBody;
    private Collider2D Plant;


    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        boxBorder.GetComponent<BoxCollider2D>().bounds.SetMinMax(new Vector3(-5,-5,0), new Vector3(5,5,0));
        Sspeed = speed;
    }

    public void EnemyFlyMovement()
    {
        while (stop != true) {
            int randX = Random.Range(-5, 5);
            int randY = Random.Range(-5, 5);
            Vector3 newDestination = new Vector3(transform.position.x + randX, transform.position.y + randY, 0f);
            if (isWithinRange(newDestination))
            {
                stop = true;
                newPosition = newDestination;
            }
        }
    }

    public bool isWithinRange(Vector3 newDestination)
    {
        return boxBorder.GetComponent<BoxCollider2D>().bounds.Contains(newDestination);
    }
    public void LookForPlant()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, FindingRadius);
        for (int i = 0; i < colliders.Length; ++i)
        {
            if (colliders[i].CompareTag("Tower"))
            {
                Plant = colliders[i];
                if (Plant.GetComponent<TowerTimer>().timerLife >= 1f)
                {
                    break;
                }
                else
                {
                    Plant = null;
                }
            }
        }
        if (Plant != null)
        {
            newPosition = Plant.transform.position;
            atPlant = true;
            stop = true;
        }
    }
    void Update()
    {
        EnemyFlyMovement();
        if (atPlant == false)
        {
            LookForPlant();
        }

                
        Vector3 OurDirection = newPosition - transform.position;
        float angle = Mathf.Atan2(OurDirection.y, OurDirection.x) * Mathf.Rad2Deg - 90f;
        OurDirection.Normalize();
        move = OurDirection;


        if (atPlant == true)
        {
            float distance = Vector3.Distance(transform.position, newPosition);
            if (distance <= StopDistance)
            {

                Plant.GetComponent<TowerTimer>().timerLife -= AttackDmg;
                if (Plant.GetComponent<TowerTimer>().timerLife <= 0)
                {
                    speed = Sspeed;
                    atPlant = false;
                    stop = false;
                    Plant = null;
                }
                speed = StopSpeed;
            }
            if (distance <= 3f && atPlant == false)
            {
                speed = Sspeed;
                atPlant = false;
                stop = false;
            }
            else {
                myBody.rotation = angle;
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
                if (transform.position == newPosition)
                {
                    atPlant = false;
                }
            }
        }
        else
        {
            myBody.rotation = angle;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
            if (transform.position == newPosition)
            {
                stop = false;
            }
        }
    }
}
