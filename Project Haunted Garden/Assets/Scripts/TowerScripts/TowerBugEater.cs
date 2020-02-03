using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBugEater : MonoBehaviour
{
    public float EatTimer;
    public float StopEating;
    public float radius;

    public bool Eating;
    public bool held;
    // Start is called before the first frame update
    void Start()
    {
        EatTimer = 0f;
        Eating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!held)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            if (colliders.Length > 0 && !Eating)
            {
                Eating = true;
                //Eats the first object it sees or one furthest away from it within the radius when done eating 
                Destroy(colliders[0].gameObject);
            }
            if (Eating)
            {
                EatTimer += Time.deltaTime;
                GetComponent<TowerHealth>().THealth += Time.deltaTime;
                if (EatTimer >= StopEating)
                {
                    GetComponent<TowerHealth>().THealth = Mathf.Round(GetComponent<TowerHealth>().THealth);
                    Eating = false;
                    EatTimer = 0f;
                }
            }
        }
    }
}
