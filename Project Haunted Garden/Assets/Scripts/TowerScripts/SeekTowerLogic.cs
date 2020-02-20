using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTowerLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private DTowerRange Range;
    public GameObject focus;
    public GameObject bulletPrefab;
    public bool bulletsPierce = false;
    public int bulletSpeed = 10;
    public float bulletPower = .5f;
    public float cooldownInSeconds = 1f;
    public int bulletLife = 20;
    public float bulletDiameter = 1f;
    public bool seesTarget = false;
    public bool allowedToShoot = true;
    public Sprite bulletSprite;
    public Color bulletColor;
    private Vector2 move;

    Animator anim;
    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        Range = GetComponent<DTowerRange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (focus != null && seesTarget && allowedToShoot)
        {
            ShootBall();
            StartCoroutine(Wait(cooldownInSeconds));
        }

        if(focus != null)
        {
            anim.SetTrigger("MakeShoot");
        }
        else
        {
            anim.SetTrigger("MakeIdle");
        }
    }

    IEnumerator Wait(float cd)
    {
        allowedToShoot = false;
        yield return new WaitForSecondsRealtime(cd);
        allowedToShoot = true;

    }
    public void ShootBall()
    {
        Vector3 OurDirection = focus.transform.position - transform.position;
        float distance = Vector3.Distance(transform.position, focus.transform.position);
        if (distance <= 10f) {
            float angle = Mathf.Atan2(OurDirection.y, OurDirection.x) * Mathf.Rad2Deg;
            OurDirection.Normalize();
            move = OurDirection;
            //GetComponent<Rigidbody2D>().rotation = angle;
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            BulletLogic newBulletLogic = newBullet.gameObject.GetComponent<BulletLogic>();
            newBullet.transform.up = focus.transform.position - newBullet.transform.position;
            newBullet.GetComponent<CircleCollider2D>().radius = .15f;
            newBulletLogic.SetLife(bulletLife);
            newBulletLogic.SetSpeed(bulletSpeed);
            newBulletLogic.SetPower(bulletPower);
            newBulletLogic.SetFoggy(false);
            newBulletLogic.SetPierce(bulletsPierce);
            Vector2 heading = transform.position - focus.transform.position;
            newBulletLogic.SetDirection( -heading / heading.magnitude );
            newBulletLogic.SetShotFromGun(false);
            newBulletLogic.SetDiameter(bulletDiameter);
            newBullet.GetComponentInParent<SpriteRenderer>().sprite = bulletSprite;
            newBullet.GetComponentInParent<SpriteRenderer>().color = bulletColor;
        }
    }
}
