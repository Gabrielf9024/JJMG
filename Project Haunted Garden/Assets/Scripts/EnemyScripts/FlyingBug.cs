using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBug : MonoBehaviour
{
    public float speed;
    public float SwapDirection;
    private Rigidbody2D myBody;
    public GameObject boxBorder;
    private bool stop = false;
    private bool atPlant = false;
    public Vector3 newPosition;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        boxBorder.GetComponent<BoxCollider2D>().bounds.SetMinMax(new Vector3(-5,-5,0), new Vector3(5,5,0));
    }

    public void EnemyFlyMovement()
    {
        while (!stop) {
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        Collider2D Plant = null; 
        for (int i = 0; i < colliders.Length; ++i)
        {
            if (colliders[i].CompareTag("Tower"))
            {
                Plant = colliders[i];
                break;
            }
        }
        if (Plant != null)
        {
            newPosition = Plant.transform.position;
            atPlant = true;
        }
    }
    void checkDistance()
    {


    }
    void Update()
    {
        EnemyFlyMovement();
        LookForPlant();
        
        transform.position = Vector3.MoveTowards(transform.position,newPosition, speed * Time.deltaTime);
        
        Vector3 OurDirection = newPosition - transform.position;
        float angle = Mathf.Atan2(OurDirection.y, OurDirection.x) * Mathf.Rad2Deg + 90f;
        OurDirection.Normalize();
        myBody.rotation = angle;

        if (atPlant)
        {
            stop = false;
            checkDistance();
        }

        if (transform.position == newPosition)
        {
            stop = false;
        }
    }
}
