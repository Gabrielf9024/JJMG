using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public bool canBeDropped = true;
    public bool pickedUp = false;
    public GameObject nearbyParent = null;
    public bool canBeOnPath = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            gameObject.transform.position = nearbyParent.gameObject.transform.position;;
        }
    }

    public void PickUp()
    {
        pickedUp = true;
        //GetComponentInChildren<TowerShoot>().allowedToShoot = false;
    }
    public void PutDown()
    {
        pickedUp = false;
        //GetComponentInChildren<TowerShoot>().allowedToShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hand")
            nearbyParent = collision.gameObject;
        if (collision.CompareTag("Path"))
            if(!canBeOnPath)
                canBeDropped = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Path"))
        {
            canBeDropped = true;
        }
    }


}
