using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBugEater : MonoBehaviour
{
    private Water waterScript;

    public float EatTimer;
    public float StopEating;
    public float radius;

    public bool Eating;
    public bool held;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        waterScript = GetComponent<Water>();
        EatTimer = 0f;
        Eating = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waterScript.dry)
            anim.SetTrigger("MakeDead");
        else if (!waterScript.dry && !Eating)
        {
            anim.SetTrigger("MakeIdle");
        }
        else if (Eating)
            anim.SetTrigger("MakeClosed");


        if (!held && !waterScript.dry)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            Collider2D food = null;

            for( int i = 0; i < colliders.Length; ++i )
            {
                if(colliders[i].CompareTag("Enemy"))
                {
                    food = colliders[i];
                    break;
                }
            }
            if (food == null)
                colliders = null;

            if (colliders != null && !Eating)
            {
                //anim.SetTrigger("MakeClosed");
                Eating = true;
                //Eats the first object it sees or one furthest away from it within the radius when done eating 
                Destroy(food.gameObject);
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
                    //anim.SetTrigger("MakeIdle");

                }
            }
        }
    }
}
