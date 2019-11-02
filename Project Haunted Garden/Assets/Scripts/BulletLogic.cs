using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    private Vector2 direction;

    public int bulletPower = 5;
    public bool piercing = false;
    public bool dieAfterTime = false;
    private int lifeSpan = 100;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed;
        --lifeSpan;
        if( lifeSpan <= 0 )
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection( Vector2 newDir )
    {
        direction = newDir;
    }
    public void SetLife( int ls )
    {
        lifeSpan = ls;
    }
    public void SetSpeed( float s )
    {
        speed = s;
    }
    public void SetPower( int p )
    {
        bulletPower = p;
    }
    public void SetPierce( bool p )
    {
        piercing = p;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().damage(bulletPower);
        }

        if (piercing)
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
