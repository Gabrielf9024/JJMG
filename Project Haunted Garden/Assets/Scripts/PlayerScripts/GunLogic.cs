﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    bool notPressing = false;



    public bool allowedToShoot = true;
    [SerializeField] GameObject bullet;
    private BulletLogic bl;

    [Header("GunMovement")]
    public float armLength = 1f;
    private Transform rotationPoint;
    private string shootControl;
    private string waterControl;
    public bool currentlyShooting = false;
    private float nextFire = 0f;



    [Header("Gun Mode")]
    public bool water = false;
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
    public float secBetweenShotsWater = .2f;
    public float fogDamage = 1;
    public float fogDamageMitigationBeforeStopped = 0.5f;
    public int bulletsPerArc = 5;
    public int bulletsPerArcWater = 10;
    public float arcWidth = 5f;
    public float fogBulletSpeed = 1f;
    public float fogBulletDiameter = .1f;
    public float fogBulletDiWater = .4f;
    public Color startingFog;
    public Color endingFog;
    public Color startingFogWater;
    public Color endingFogWater;
    public float lifeSpanWater;
    public float startingSize = 0.1f;
    public float endingSize = 0.5f;


    [Header("Images for Guns")]
    public GameObject GunUI;
    public Sprite GreenOne;
    public Sprite PurpleOne;
    public Sprite GreenTwo;
    public Sprite PurpleTwo;
    private bool IsPurple;

    [Header("Images for Guns")]
    public GameObject GunSound;

    void Awake()
    {
        bl = bullet.GetComponent<BulletLogic>();
        rotationPoint = transform.parent.transform;
        shootControl = GameObject.FindWithTag("Player").GetComponent<HeroMovement>().shootControl;
        waterControl = GameObject.FindWithTag("Player").GetComponent<HeroMovement>().waterControl;
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

        if (Input.GetAxisRaw(shootControl) != 0 || Input.GetAxisRaw(waterControl) != 0) {
            if (Input.GetAxisRaw(waterControl) != 0)
                water = true;
            else
                water = false;



            if (allowedToShoot)
            {
                if( automatic )
                {
                    if (!currentlyShooting || Time.time > nextFire)
                    {
                        if (spread)
                        {
                            bl.water = water;
                            bl.SetPierce(false);
                            bl.useRandomSpeed = true;
                            bl.SetSpeed(fogBulletSpeed);
                            bl.SetDiameter(fogBulletDiameter);

                            if(water)
                            {
                                bl.waterValue = .1f;

                                bl.SetPierce(true);
                                bl.startingFog = startingFogWater;
                                bl.endingFog = endingFogWater;
                                bl.SetFoggy(false);
                                bl.SetDiameter(fogBulletDiWater);
                                bl.lifeSpan = lifeSpanWater;
                            }
                            else
                            {
                                bl.startingFog = startingFog;
                                bl.endingFog = endingFog;
                                bl.SetFoggy(true);
                                bl.lifeSpan = 150;
                            }

                            bl.startingSize = startingSize;
                            bl.endingSize = endingSize;
                            bl.SetPower(fogDamage * fogDamageMitigationBeforeStopped);
                            currentlyShooting = true;
                            ShootSpread(centerToMouseDir);
                            GunUI.GetComponent<Image>().sprite = GreenTwo;
                            GunSound.GetComponent<AudioSource>().Play();
                        }
                    }
                }
                else
                {
                    if (!currentlyShooting)
                    {
                        bl.water = water;
                        if (water)
                        {
                            bl.SetPierce(true);
                            bl.waterValue = 10;
                        }
                        else
                        {
                            bl.SetPierce(false);
                        }
                        bl.SetFoggy(false);
                        bl.useRandomSpeed = false;
                        bl.SetSpeed(semiAutoBulletSpeed);
                        bl.SetDiameter(semiAutoBulletDiameter);

                        bl.SetPower(semiAutoDamage);
                        
                        currentlyShooting = true;
                        if (straight)
                        {
                            ShootStraight(centerToMouseDir);
                            GunUI.GetComponent<Image>().sprite = PurpleTwo;
                            GunSound.GetComponent<AudioSource>().Play();
                        }
                    }
                }
            }
        }
        if (Input.GetAxisRaw(shootControl) == 0 && Input.GetAxisRaw(waterControl) == 0)
        {
            currentlyShooting = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if (notPressing)
            {
                notPressing = false;
                if (straight)
                {
                    straight = false;
                    spread = automatic = true;
                    IsPurple = false;
                    GunUI.GetComponent<Image>().sprite = GreenOne;
                }
                else
                {
                    straight = true;
                    spread = automatic = false;
                    IsPurple = true;
                    GunUI.GetComponent<Image>().sprite = PurpleOne;
                }
            }
        }
        else
        {
            notPressing = true;
        }
        if (currentlyShooting == false && IsPurple == true)
        {
            GunUI.GetComponent<Image>().sprite = PurpleOne;
        }
        if (currentlyShooting == false && IsPurple == false)
        {
            GunUI.GetComponent<Image>().sprite = GreenOne;
        }
    }

    public void ShootStraight( Vector2 direction )
    {
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

        if (water)
            nextFire = Time.time + secBetweenShotsWater;
        else
            nextFire = Time.time + secBetweenShots;

        GameObject newBullet = null;

        int bp = bulletsPerArc;
        if (water)
            bp = bulletsPerArcWater;

        for ( int i = 0; i < bp; ++i )
        {
            newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            float offset = Random.Range(-arcWidth, arcWidth);
            direction = direction.Rotate(offset);
            newBullet.GetComponent<BulletLogic>().SetDirection(direction.normalized);
            direction = original;

        }


    }
}
