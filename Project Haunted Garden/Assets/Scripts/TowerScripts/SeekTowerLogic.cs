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
    public int cooldown = 20;
    public int bulletLife = 20;
    public bool seesTarget = false;

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
        if (focus != null && seesTarget)
        {
            ShootBall();
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
            newBulletLogic.SetLife(bulletLife);
            newBulletLogic.SetSpeed(bulletSpeed);
            newBulletLogic.SetPower(bulletPower);
            newBulletLogic.SetFoggy(false);
            newBulletLogic.SetPierce(bulletsPierce);
            newBulletLogic.SetDirection((focus.transform.position - transform.position ) * 3.5f);
            newBulletLogic.SetShotFromGun(false);
            newBulletLogic.SetDiameter(0.2f);
        }
    }
}
