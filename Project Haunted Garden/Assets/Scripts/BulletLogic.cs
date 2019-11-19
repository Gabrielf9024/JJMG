using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    private Vector2 direction;

    public int bulletPower = 5;
    public bool piercing = false;
    public bool foggy = false;
    public float fogSlowdown = .1f;
    public bool dieAfterTime = true;
    public bool dieSlowly = false;
    public float slowDeathSpeed = 1.0f;
    private bool doneDying = false;
    public bool shotFromGun = false;
    public float randomVariator = 10f; //affects the variability of stats
    public float lifeSpan = 100;
    private float randomSpeed;
    private SpriteRenderer r;

    private Rigidbody2D rb;

    void Awake()
    {
        r = GetComponent<SpriteRenderer>();
        randomSpeed = Random.Range(0.5f, 1.5f);
        rb = GetComponent<Rigidbody2D>();
        lifeSpan += Random.Range(-randomVariator, randomVariator);
        if (foggy)
            GetComponent<CircleCollider2D>().enabled = false;
    }

    void FixedUpdate()
    {
        if( foggy )
        {
            StartCoroutine(SlowBullets());
        }

        rb.velocity = direction * speed;
        if (shotFromGun)
        {
            rb.velocity *= randomSpeed;
            rb.velocity += GetComponentInParent<Rigidbody2D>().velocity;
        }

        --lifeSpan;
        if( lifeSpan <= 0 && dieAfterTime)
        {
            if (dieSlowly)
            {
                StartCoroutine(SlowDeath(0f, slowDeathSpeed));
                if (doneDying)
                    Destroy(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }

    IEnumerator SlowBullets()
    {
        speed -= fogSlowdown ;
        if (speed < 0)
        {
            GetComponent<CircleCollider2D>().enabled = true;
            speed = 0;
        }
        yield return new WaitForSecondsRealtime(1f);
    }

    IEnumerator SlowDeath( float aValue, float aTime )
    {
        float alpha = r.material.color.a;

        for( float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime )
        {
            Color newColor = new Color(r.color.r, r.color.g, r.color.b, Mathf.Lerp(alpha, aValue, t));
            r.material.color = newColor;
            yield return null;
        }
        doneDying = true;
    }

    public void SetDirection( Vector2 newDir ) {direction = newDir;}
    public void SetLife( int ls ) {lifeSpan = ls;}
    public void SetSpeed( float s ) {speed = s;}
    public void SetPower( int p ) {bulletPower = p;}
    public void SetPierce( bool p ) {piercing = p;}
    public void SetFoggy( bool f ) {foggy = f;}
    public void SetSlowDeath( bool sd ) { dieSlowly = sd;}
    public void SetShotFromGun( bool fg ) { shotFromGun = fg; }
    
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
