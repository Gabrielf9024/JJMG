using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private Inventory inventory;
    //private Equiptment equipt;
    public GameObject itemButton;
    //public GameObject IconLocation;
    // Start is called before the first frame update
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
    //void AddItemToEquiptTab()
    //{
    //    if (itemButton.CompareTag("Tower") || itemButton.CompareTag("Player"))
    //    {
    //        equipt.equiptment[equipt.size] = itemButton;
    //        equipt.size++;
    //        Instantiate(itemButton, IconLocation.transform, false);
    //    }
    //}
}
