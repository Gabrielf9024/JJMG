using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    private Vector2 direction;

    public bool dieAfterTime = false;
    private int lifeSpan;

    private Rigidbody2D rb;
    public Color bulletColor;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletColor = this.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        rb.velocity = direction * speed;
    }

    public void SetDirection( Vector2 newDir )
    {
        direction = newDir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            ; // hurt enemy
        }
        Destroy( gameObject );
    }
}
