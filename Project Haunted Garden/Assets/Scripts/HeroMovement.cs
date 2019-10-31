using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{

    [Header("Movement Stats")]
    [SerializeField] float speed = 5f;

    private Rigidbody2D rb;

    string horizontalControl;
    string verticalControl;

    public string shootControl;
    public string pickupControl;
    public bool rawInputOn = true;


    private float xInput = 0;
    private float yInput = 0;
    public GameObject closestPickupable = null;
    private bool pickupInUse = false;

    void Start()
    {
        horizontalControl = "Horizontal";
        verticalControl = "Vertical";

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rawInputOn) {
            xInput = Input.GetAxisRaw(horizontalControl);
            yInput = Input.GetAxisRaw(verticalControl);
        }
        else {
            xInput = Input.GetAxis(horizontalControl);
            yInput = Input.GetAxis(verticalControl);
        }


        if (Input.GetAxisRaw(pickupControl) != 0 && closestPickupable != null)
        {
            if( !pickupInUse )
            {
                pickupInUse = true;

                if (closestPickupable.GetComponent<Movable>().pickedUp == false)
                    closestPickupable.GetComponent<Movable>().PickUp();
                else
                {
                    closestPickupable.GetComponent<Movable>().PutDown();
                    closestPickupable = null;
                }
            }
        }
        if (Input.GetAxisRaw(pickupControl) == 0)
            pickupInUse = false;

        rb.velocity = new Vector2(xInput * speed, yInput * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tower")
        {
            closestPickupable = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }




}
