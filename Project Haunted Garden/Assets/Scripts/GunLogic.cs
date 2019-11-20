using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Vector2Extension Courtesy of:
// https://answers.unity.com/questions/661383/whats-the-most-efficient-way-to-rotate-a-vector2-o.html
// Used in ShootSpread()
public static class Vector2Extension
{

    public static Vector2 Rotate(this Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}
/// End Courtesy///
public class GunLogic : MonoBehaviour
{
    public bool allowedToShoot = true;
    [SerializeField] GameObject bullet;
    private BulletLogic bl;

    [Header("GunMovement")]
    public float armLength = 1f;
    private Transform rotationPoint;
    private string shootControl;
    private bool currentlyShooting = false;
    private float nextFire = 0f;
    


    [Header("Gun Mode")]
    public bool automatic = false;
    public bool straight = true;
    public bool spread = false;

    [Header("Straight")]
    public float semiAutoDamage = 50;
    public float semiAutoBulletSpeed = 10f;
    public float cooldownInSec = 1f;
    public float semiAutoBulletDiameter = .75f;

    [Header("Spread")]
    [SerializeField] float secBetweenShots = 1f;
    public float fogDamage = 1;
    public float fogDamageMitigationBeforeStopped = 0.5f;
    public int bulletsPerArc = 5;
    public float arcWidth = 5f;
    public float fogBulletSpeed = 1f;
    public float fogBulletDiameter = .1f;


    void Awake()
    {
        bl = bullet.GetComponent<BulletLogic>();
        rotationPoint = transform.parent.transform;
        shootControl = GameObject.FindWithTag("Player").GetComponent<HeroMovement>().shootControl;
    }

    void FixedUpdate()
    {
        // Get direction from player to mouse
        Vector3 centerToMouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - rotationPoint.position;

        // This puts the gun right above the player on the z-axis
        centerToMouseDir.z = -.43f;

        // Put the gun in that direction, as far as the armlength
        Vector3 gunDistanceFromSelf = armLength * centerToMouseDir.normalized;
        transform.position = rotationPoint.position + gunDistanceFromSelf;

        if (Input.GetAxisRaw(shootControl) != 0) {
            if (allowedToShoot)
            {
                if( automatic )
                {
                    if (!currentlyShooting || Time.time > nextFire)
                    {
                        if (spread)
                        {
                            bl.SetPierce(false);
                            bl.SetFoggy(true);
                            bl.useRandomSpeed = true;
                            bl.SetSpeed(fogBulletSpeed);
                            bl.SetDiameter(fogBulletDiameter);

                            bl.SetPower(fogDamage * fogDamageMitigationBeforeStopped);
                            currentlyShooting = true;
                            ShootSpread(centerToMouseDir);
                        }
                    }
                 }
                else
                {
                    if (!currentlyShooting)
                    {
                        bl.SetPierce(false);
                        bl.SetFoggy(false);
                        bl.useRandomSpeed = false;
                        bl.SetSpeed(semiAutoBulletSpeed);
                        bl.SetDiameter(semiAutoBulletDiameter);

                        bl.SetPower(semiAutoDamage);

                        currentlyShooting = true;
                        if (straight)
                            ShootStraight(centerToMouseDir);
                    }

                }
            }
        }
        if (Input.GetAxisRaw(shootControl) == 0)
        {
            currentlyShooting = false;
        }

        //if(Input.GetAxis("Mouse ScrollWheel") != 0)
        if( Input.GetKeyDown(KeyCode.Q))
        {
            if( straight )
            {
                straight = false;
                spread = automatic = true;
            }
            else
            {
                straight = true;
                spread = automatic = false;
            }
        }

    }

    public void ShootStraight( Vector2 direction )
    {
        nextFire = Time.time + secBetweenShots;
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity );
        newBullet.GetComponent<BulletLogic>().SetDirection( direction.normalized );
        StartCoroutine(Wait(cooldownInSec));
    }
    IEnumerator Wait( float cd )
    {
        allowedToShoot = false;
        yield return new WaitForSecondsRealtime(cd);
        allowedToShoot = true;

    }

    public void ShootSpread( Vector2 direction )
    {
        Vector2 original = direction;
        nextFire = Time.time + secBetweenShots;
        GameObject newBullet = null;
        for ( int i = 0; i < bulletsPerArc; ++i )
        {
            newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            float offset = Random.Range(-arcWidth, arcWidth);
            direction = direction.Rotate(offset);
            newBullet.GetComponent<BulletLogic>().SetDirection(direction.normalized);
            direction = original;

        }


    }
}
