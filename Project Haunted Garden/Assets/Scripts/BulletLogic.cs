using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    private Vector2 direction;

    public int bulletPower = 1;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().damage(bulletPower);
        }
        Destroy( gameObject );
    }
}
