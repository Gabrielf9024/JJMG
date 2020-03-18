using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBomber : MonoBehaviour
{

    [Header("Bug Stats" )]
    public float dmg;
    public float radius;

    private bool Explode;
    // Start is called before the first frame update
    void Start()
    {
        Explode = false;
    }
    void Update()
    {
        TimeToExplode();
    }
    public void TimeToExplode()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D otherObject in colliders)
        {
            if (otherObject.tag == "Tower")
            {
                otherObject.GetComponent<TowerTimer>().timerLife -= dmg;
                Explode = true;
            }
            if (otherObject.tag == "Player")
            {
                //stun
            }
        }
        if (Explode == true)
        { Destroy(gameObject); }
    }
}
