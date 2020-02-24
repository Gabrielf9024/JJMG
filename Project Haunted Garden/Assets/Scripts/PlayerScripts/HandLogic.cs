using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLogic : MonoBehaviour
{
    private Inventory inventory;
    private Slot slot;
    public GameObject closest = null;
    public bool holding = false;
    public bool showHand = false;
    public Sprite handSprite = null;
    public string pickupControl = "Fire2";
    public bool pickupBeingUsed = false;
    private GameObject Store;
    public Sprite seed = null;
    public bool showSeed;

    // tissue test
    public bool shopping = false;
    //public GameObject tower;

    // Start is called before the first frame update
    void Awake()
    {
        inventory = GetComponentInParent<Inventory>();
        Store = GameObject.Find("StorePanel");
    }

    // Update is called once per frame
    void Update()
    {
        UseItem();
        if (Input.GetAxisRaw(pickupControl) != 0 && !pickupBeingUsed)
        {
            pickupBeingUsed = true;

            //For the towerbox, throw away after tissue test
            if (!holding && shopping) //if they right click the box
            {
                Store.SetActive(true);
                holding = true; showHand = false;
                GetComponent<CircleCollider2D>().enabled = false;
                GetComponentInParent<GunLogic>().allowedToShoot = false;
                GetComponentInParent<Rigidbody2D>().velocity = new Vector3 (0,0,0);
                GetComponentInParent<HeroMovement>().enabled = false;
            }

            else if (!holding && showHand) //if they want to pick up
            {
                GameObject temp = closest;
                showHand = false;
                holding = true;
                PickUp(closest);
                GetComponent<CircleCollider2D>().enabled = false;
                closest = temp;
                GetComponentInParent<GunLogic>().allowedToShoot = false;
            }
            else if (holding && closest.GetComponent<Movable>().canBeDropped) //if they want to drop
            {
                showHand = true;
                holding = false;
                PutDown(closest);
                GetComponent<CircleCollider2D>().enabled = true;
                GetComponentInParent<GunLogic>().allowedToShoot = true;

            }

        }

        if (Input.GetAxisRaw(pickupControl) == 0)
            pickupBeingUsed = false;

        if (showHand)
            gameObject.GetComponent<SpriteRenderer>().sprite = handSprite;
        if(showHand == false && showSeed == false)
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }
    public void createObject(GameObject icon, string name)
    {
        int minus = 0;
        if (name == "Aim Tower $150")
        {
            minus = -150;
        }
        else
        {
            minus = -100; 
        }
        if (isPossible(minus) && icon != null)
        {
            GameObject newTower = Instantiate(icon, transform.position, transform.rotation);
            newTower.GetComponent<Movable>().PickUp();
            newTower.GetComponent<Movable>().nearbyParent = gameObject;
            holding = true; showHand = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponentInParent<GunLogic>().allowedToShoot = false;
            closest = newTower;
            GameObject.Find("GameManager").GetComponent<GameManager>().baseMoney += minus;
            Store.SetActive(false);
            GetComponentInParent<HeroMovement>().enabled = true;
        }
        else
        {
            GetComponentInParent<HeroMovement>().enabled = false;
            holding = false; showHand = false;
            GetComponent<CircleCollider2D>().enabled = true;
            GetComponentInParent<GunLogic>().allowedToShoot = true;
            Store.SetActive(false);
            GetComponentInParent<HeroMovement>().enabled = true;
        }
    }
    private bool isPossible(int minus)
    {
        return GameObject.Find("GameManager").GetComponent<GameManager>().baseMoney + minus >= 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tower")
        {
            closest = collision.gameObject;
            showHand = true;
        }

        if(collision.tag == "Shop")
        {
            shopping = true;
            showHand = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        closest = null;
        showHand = false;

        if (collision.tag == "Shop")
        {
            shopping = false;
        }
    }

    public void PickUp( GameObject c)
    {
        c.GetComponent<Movable>().PickUp();
    }
    public void PutDown( GameObject c)
    {
        c.GetComponent<Movable>().PutDown();
    }
    
    public void UseItem()
    {
        if (Input.GetKeyDown("1")){
            if (inventory.slots[0].transform.GetChild(0).transform != null)
            {
                showSeed = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = seed;
                GameObject.Destroy(inventory.slots[0].transform.GetChild(0).gameObject);
            }
            
        }
        if (Input.GetKeyDown("2"))
        {
            if (inventory.slots[1].transform.GetChild(0).transform != null)
            {
                Instantiate(inventory.slots[1].transform.GetChild(0).transform, transform, false);
                GameObject.Destroy(inventory.slots[1].transform.GetChild(0).gameObject);
            }
        }
        if (Input.GetKeyDown("3"))
        {
            if (inventory.slots[2].transform.GetChild(0).transform != null)
            {
                Instantiate(inventory.slots[2].transform.GetChild(0).transform, transform, false);
                GameObject.Destroy(inventory.slots[2].transform.GetChild(0).gameObject);
            }
        }
        if (Input.GetKeyDown("4"))
        {
            if (inventory.slots[3].transform.GetChild(0).transform != null)
            {
                Instantiate(inventory.slots[3].transform.GetChild(0).transform, transform, false);
                GameObject.Destroy(inventory.slots[3].transform.GetChild(0).gameObject);
            }
        }
    }

}
