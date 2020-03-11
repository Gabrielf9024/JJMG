using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBomb : MonoBehaviour
{
    public float TExplode;
    public float dmg;
    public float radius;
    public bool countDown = false;

    public bool Explode;
    public bool held;



    // Start is called before the first frame update
    void Start()
    {
        Explode = false;
        held = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( countDown )
        {
            if (TExplode >= 0 && !Explode && !held)
            {
                TExplode -= Time.deltaTime;
            }
            if (TExplode >= 0 && !Explode && held)
            {
                TExplode -= Time.deltaTime * .5f;
            }
        }
        TimeToExplode();
    }
    public void TimeToExplode()
    {
        if (TExplode <= 0f)
        {
            Explode = true;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach(Collider2D otherObject in colliders)
            {
                if (otherObject.tag == "Enemy" && !held)
                {
                    otherObject.GetComponent<EnemyHealth>().damage(dmg);
                }
                if (otherObject.tag == "Enemy" && held)
                {
                    otherObject.GetComponent<EnemyHealth>().damage(dmg * .50f);
                }
                if (otherObject.tag == "Player")
                {
                    //stun
                }
            }
            --GetComponentInParent<BombSpawn>().bombCount;
            Destroy(gameObject);
            
        }
    }
}
