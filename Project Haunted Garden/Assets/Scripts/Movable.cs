using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public bool pickedUp = false;
    public GameObject nearbyParent = null;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (pickedUp)
            gameObject.transform.parent = nearbyParent.gameObject.transform;
        else
            gameObject.transform.parent = null;
    }

    public void PickUp()
    {
        pickedUp = true;
    }
    public void PutDown()
    {
        pickedUp = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            nearbyParent = collision.gameObject;
    }

}
