using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class GunLogic : MonoBehaviour
{
    [Header("GunMovement")]
    public float armLength = 1f;
    private Transform rotationPoint;
    private string shootControl;
    private bool currentlyShooting = false;
    private float nextFire = 0f;
    

    [SerializeField] float autoSecBetweenShots = 1f;
    [SerializeField] GameObject bullet;

    public bool straight = true;
    public bool spread = false;

    [Header("Spread")]
    public int bulletsPerArc = 5;
    public float arcWidth = 5f;
    public int arcBulletDamage = 1;

    void Awake()
    {
        rotationPoint = transform.parent.transform;
        shootControl = GameObject.FindWithTag("Player").GetComponent<HeroMovement>().shootControl;
    }

    void Update()
    {
        // Get direction from player to mouse
        Vector3 centerToMouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - rotationPoint.position;

        // This puts the gun right above the player on the z-axis
        centerToMouseDir.z = -.43f;

        // Put the gun in that direction, as far as the armlength
        Vector3 gunDistanceFromSelf = armLength * centerToMouseDir.normalized;
        transform.position = rotationPoint.position + gunDistanceFromSelf;

        if (Input.GetAxisRaw(shootControl) != 0) {
            if (!currentlyShooting || Time.time > nextFire) {
                if( straight )
                    ShootStraight(centerToMouseDir);
                if( spread )
                {
                    ShootSpread(centerToMouseDir);
                }
            }
        }
        if (Input.GetAxisRaw(shootControl) == 0)
        {
            currentlyShooting = false;
        }

    }

    public void ShootStraight( Vector2 direction )
    {
        currentlyShooting = true;

        nextFire = Time.time + autoSecBetweenShots;
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity );
        newBullet.GetComponent<BulletLogic>().SetDirection( direction.normalized );

    }

    public void ShootSpread( Vector2 direction )
    {
        currentlyShooting = true;
        Vector2 original = direction;
        nextFire = Time.time + autoSecBetweenShots;

        for ( int i = 0; i < bulletsPerArc; ++i )
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            float offset = Random.Range(-arcWidth, arcWidth);
            direction = direction.Rotate(offset);
            newBullet.GetComponent<BulletLogic>().SetDirection(direction.normalized);
            newBullet.GetComponent<BulletLogic>().SetPower(arcBulletDamage);
            direction = original;
        }

    }
}
