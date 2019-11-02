using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLogic : MonoBehaviour
{

    public GameObject closest = null;
    public bool holding = false;
    public bool showHand = false;
    public Sprite handSprite = null;
    public string pickupControl = "Fire2";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw(pickupControl) != 0)
        {
            if (!holding && showHand)
            {
                holding = true;
                PickUp(closest);
            }
            else if (holding)
            {
                holding = false;
                PutDown(closest);
            }
        }

        if (showHand)
            gameObject.GetComponent<SpriteRenderer>().sprite = handSprite;
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tower")
        {
            closest = collision.gameObject;
            showHand = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        closest = null;
        showHand = false;
    }

    public void PickUp( GameObject c)
    {
        c.GetComponent<Movable>().PickUp();
    }
    public void PutDown( GameObject c)
    {
        c.GetComponent <Movable>().PutDown();
    }
}
