using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestMe : MonoBehaviour
{
    public bool harvested;
    public bool CanHarvest;
    public float HarvestTimeSeeds;
    //public float max_harvest_time_seeds;

    //public int Max_seeds;
    //public int min_seeds;

    private Inventory inventory;
    public GameObject itemButton;
    private int check = 0;


    private float timeElapsed;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
        CheckHarvestTime();
    }
    public void CheckHarvestTime()
    {
        if (timeElapsed >= HarvestTimeSeeds)
        {
            CanHarvest = true;
        }
        else
        {
            CanHarvest = false;
        }
    }
    public void AmountToGive()
    {
        if (CanHarvest)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    check++;
                    break;
                }
            }
            timeElapsed = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (check < 4)
            {
                AmountToGive();
                harvested = true;
                CanHarvest = false;
            }
        }
    }
}
