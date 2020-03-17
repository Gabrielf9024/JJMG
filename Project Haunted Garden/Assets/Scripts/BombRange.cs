using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRange : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("Enemy"))
        {
            if( !GetComponentInParent<Movable>().pickedUp )
            {
                GetComponentInParent<TowerBomb>().countDown = true;
                anim.SetFloat("Speed", 5f);
                GetComponentInParent<Movable>().enabled = false;
            }
        }
    }
}
