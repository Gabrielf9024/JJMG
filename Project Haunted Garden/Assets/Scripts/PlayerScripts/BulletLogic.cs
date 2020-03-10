using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    private Vector2 direction;
    public float bulletPower = 5;

    [Header("Toggles")]
    public bool water = false;
    public bool piercing = false;
    public bool foggy = false;
    public bool dieAfterTime = true;
    public bool shotFromGun = false;
    public bool useRandomSpeed = false;

    [Header("Viewable for Debugging")]
    public float fogSlowdown = .1f;
    public float slowDeathSpeed = 1.0f;
    public float randomVariator = 10f; //affects the variability of stats
    public float lifeSpan = 100;
    private float randomSpeed;
    private SpriteRenderer r;

    public Color waterColor;
    public float waterValue = 1f;

    public Color startingFog;
    public Color endingFog;
    public float startingSize = 0.1f;
    public float endingSize = 0.5f;

    private float t = 0.0f;

    private Rigidbody2D rb;

    void Awake()
    {
        r = GetComponent<SpriteRenderer>();
        randomSpeed = Random.Range(0.5f, 1.5f);
        rb = GetComponent<Rigidbody2D>();

        if(!water)
        {
            lifeSpan += Random.Range(-randomVariator, randomVariator);
            gameObject.layer = 8; //Projectile
        }
        else
        {
            tag = "WaterProjectile";
            GetComponent<SpriteRenderer>().color = waterColor;
            gameObject.layer = 14; //Water
        }
    }

    void FixedUpdate()
    {
        if( foggy )
        {
            StartCoroutine(SlowBullets());
            SetPierce(true);

            transform.localScale = new Vector3(Mathf.Lerp(startingSize , endingSize, t), Mathf.Lerp(startingSize, endingSize, t), 0);
            GetComponent<SpriteRenderer>().color = Color.Lerp(startingFog, endingFog, t);
            t += 0.25f * Time.deltaTime;

        }

        
        rb.velocity = direction * speed;
        if (shotFromGun)
        {
            if(useRandomSpeed)
                rb.velocity *= randomSpeed;
            rb.velocity += GetComponentInParent<Rigidbody2D>().velocity;
        }



        --lifeSpan;
        if( lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SlowBullets()
    {
        speed -= fogSlowdown ;
        if (speed < 0)
        {
            speed = 0;
            bulletPower = GameObject.Find("Gun").GetComponent<GunLogic>().fogDamage;
        }
        yield return new WaitForSecondsRealtime(.5f);
    }

    public void SetDirection( Vector2 newDir ) {direction = newDir;}
    public void SetLife( int ls ) {lifeSpan = ls;}
    public void SetSpeed( float s ) {speed = s;}
    public void SetPower( float p ) {bulletPower = p;}
    public void SetPierce( bool p ) {piercing = p;}
    public void SetFoggy( bool f ) {foggy = f;}
    public void SetShotFromGun( bool fg ) { shotFromGun = fg; }
    public void SetDiameter( float d )
    {
        transform.localScale = new Vector3(d, d, transform.localScale.z);
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
            Debug.Log(collision.name);
            Destroy(gameObject);
        }
    }
}
