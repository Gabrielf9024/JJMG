using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool seesTarget = false;
    public bool allowedToShoot = true;
    [TextArea]
    public string Notes = "Towers will shoot when an enemy is in their radius. Select what kind of tower this game object is. Selecting multiple types will turn on all selected types.";

    public bool TurnOnRing = false;
    public bool bulletsPierce = false;
    public bool bulletsAreFoggy = false;
    public int bulletSpeed = 10;
    public int bulletPower = 1;
    public int cooldown = 20;
    public int bulletLife = 20;
    public Color bulletColor;

    public float fogSlowdown = .1f;
    public float startingSize = 0.1f;
    public float endingSize = 0.5f;
    public Color start;
    public Color end;


    public bool Ring = false;
    public bool Spiral = true;

    [Header("RingShooter")]
    public int numBullets_ring = 12;
    public float circleSpawnRadius = 3f;

    [Header("BulletSpiral")]
    [SerializeField] int numBullets_spiral = 20;
    [SerializeField] int skipEvery = 1;
    [SerializeField] bool counterClockwise = false;
    [SerializeField] int spiralPositionCounter = 0;

    Animator anim;

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        spiralPositionCounter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (seesTarget)
            anim.SetTrigger("MakeShoot");
        else
        {
            anim.SetTrigger("MakeIdle");
            StopCoroutine(SpawnSpiral());
        }

        ++count;
        if (count % cooldown == 0 && seesTarget ) {
            if( TurnOnRing && allowedToShoot ) {
                if(Ring)
                    SpawnBulletRing();
                if (Spiral)
                    StartCoroutine(SpawnSpiral());
            }
        }


        // Resets count so it doesn't go too high
        if (count > 500)
            count = 0;
    }


    public void SpawnBulletRing()
    {
        Vector3 center = gameObject.transform.position;
        for (int i = 1; i <= numBullets_ring; ++i)
        {
            Vector3 pos = Circle(center, i, circleSpawnRadius, numBullets_ring);
            GameObject newBullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
            BulletLogic newBulletLogic = newBullet.gameObject.GetComponent<BulletLogic>();
            newBulletLogic.SetLife(bulletLife);
            newBulletLogic.SetSpeed(bulletSpeed);
            newBulletLogic.SetPower(bulletPower);
            newBulletLogic.SetPierce(bulletsPierce);
            newBulletLogic.SetFoggy(bulletsAreFoggy);
            newBulletLogic.SetDirection(pos - center);
            newBulletLogic.SetShotFromGun(false);
            newBulletLogic.SetDiameter(0.3f);
            newBullet.GetComponent<SpriteRenderer>().color = bulletColor;
            newBulletLogic.startingFog = start;
            newBulletLogic.endingFog = end;
            newBulletLogic.startingSize = startingSize;
            newBulletLogic.endingSize = endingSize;
            newBulletLogic.fogSlowdown = fogSlowdown;

            newBullet.GetComponent<SpriteRenderer>().color = bulletColor;
        }
    }
    IEnumerator SpawnSpiral()
    {
        while (true)
        {
            if (counterClockwise)
                spiralPositionCounter -= skipEvery;
            else
                spiralPositionCounter += skipEvery;

            Vector3 center = gameObject.transform.position;
            Vector3 pos = Circle(center, spiralPositionCounter, circleSpawnRadius, numBullets_spiral);

            GameObject newBullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
            BulletLogic newBulletLogic = newBullet.gameObject.GetComponent<BulletLogic>();
            newBulletLogic.SetLife(bulletLife);
            newBulletLogic.SetSpeed(bulletSpeed);
            newBulletLogic.SetPower(bulletPower);
            newBulletLogic.SetPierce(bulletsPierce);
            newBulletLogic.SetFoggy(bulletsAreFoggy);
            newBulletLogic.SetDirection(pos - center);
            newBulletLogic.SetShotFromGun(false);
            newBullet.GetComponent<SpriteRenderer>().color = bulletColor;
            newBulletLogic.startingFog = start;
            newBulletLogic.endingFog = end;
            yield return new WaitForSecondsRealtime(cooldown);
        }
    }

    Vector3 Circle(Vector3 center, float angleModifier, float radius, float numBullets)
    {
        angleModifier = angleModifier / numBullets;
        float ang = angleModifier * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
