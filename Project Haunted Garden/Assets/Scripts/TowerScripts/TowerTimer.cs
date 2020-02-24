using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTimer : MonoBehaviour
{
    public float timerLife;
    public float healthTimer;
    public float IncLife;

    public bool Watered;
    public bool PickedUp;

    // Start is called before the first frame update
    void Start()
    {
        Watered = false;
        PickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        WasIWatered();
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
            if (GetComponent<TowerHealth>().THealth >= 0) {
                GetComponent<TowerHealth>().THealth -= Time.deltaTime * 1.5f;
            }
        }
    }
    public void WasIWatered()
    {
       if (Watered)
        {
            if ((timerLife + IncLife) > healthTimer)
            {
                Debug.Log("check");
                float increaseby = (timerLife + IncLife);
                increaseby -= healthTimer;
                Debug.Log(increaseby);
                timerLife += increaseby;
            }
            else
            {
                timerLife += IncLife;
            }
            
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
            /*if (timerLife <=0)
            {
                GetComponent<TowerShoot>().enabled = true;
            }*/
        }
    }
    public void wasIPickedUp()
    {
        if (PickedUp)
        {
            timerLife -= timerLife * .50f;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {
                Watered = true;
            }
        }
    }
}
