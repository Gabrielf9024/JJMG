using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTimer : MonoBehaviour
{
    public float timerLife;
    public float IncLife;
    public float HarvestTimeSeeds;
    public float timeElapsed;
    private bool ready;

    public bool Watered;
    public bool PickedUp;
    private bool CanHarvest;
    private bool play;
    private bool harvested;
    private int check = 0;

    private Inventory inventory;
    public GameObject seedImage;
    public GameObject light;
    private GameObject lightPart;

    // Start is called before the first frame update
    void Start()
    {
        Watered = false;
        PickedUp = false;
        play = false;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        WasIWatered();
        if (timerLife > 0) {
            timeElapsed += Time.deltaTime;
            CheckHarvestTime();
        }
        if (timerLife > 0 && !PickedUp)
        {
            timerLife -= Time.deltaTime;
        }
        if (timerLife > 0 && PickedUp)
        {
            timerLife -= 1.0f;
            GetComponent<TowerHealth>().THealth -= .5f;
        }
        if (timerLife <= 0)
        {
            //GetComponent<TowerShoot>().enabled = false;
            GetComponent<Animator>().enabled = false;
        }
    }
    public void WasIWatered()
    {
       if (Watered)
        {
            timerLife += IncLife;
            if (GetComponent<TowerHealth>().THealth <= 50)
            {
                if (GetComponent<TowerHealth>().THealth + 10f > 50)
                {
                    float temp = GetComponent<TowerHealth>().THealth + 10f;
                    temp -= 50;
                    GetComponent<TowerHealth>().THealth += 10f - temp;
                }
                else
                {
                    GetComponent<TowerHealth>().THealth += 10f;
                }
            }
            Watered = !Watered;
            if (timerLife <=0)
            {
                GetComponent<Animator>().enabled = false;
            }
        }
    }
    public void CheckHarvestTime()
    {
        if (timeElapsed >= HarvestTimeSeeds)
        {
            if (!play)
            {
                lightPart = Instantiate(light, transform, false);
                play = true;
            }
            if (timerLife >=1)
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
                    Instantiate(seedImage, inventory.slots[i].transform, false);
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
                Destroy(lightPart, .5f);
                play = false;
                harvested = true;
                CanHarvest = false;
            }
        }
    }
    public void wasIPickedUp()
    {
        if (PickedUp)
        {
            timerLife -= timerLife * .50f;
        }
    }
}
