using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool seesTarget = false;

    [TextArea]
    public string Notes = "Towers will shoot when an enemy is in their radius. Select what kind of tower this game object is. Selecting multiple types will turn on all selected types.";

    public bool TurnOnRing = false;
    public bool bulletsPierce = false;
    public int bulletSpeed = 10;
    public int bulletPower = 1;
    public int cooldown = 20;
    public int bulletLife = 20;

    [Header("RingShooter")]
    public int numBullets_ring = 12;
    public float circleSpawnRadius = 3f;

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ++count;
        if (count % cooldown == 0 && seesTarget ) {
            if( TurnOnRing ) {
                SpawnBulletRing();
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
            newBullet.gameObject.GetComponent<BulletLogic>().SetLife(bulletLife);
            newBullet.gameObject.GetComponent<BulletLogic>().SetSpeed(bulletSpeed);
            newBullet.gameObject.GetComponent<BulletLogic>().SetPower(bulletPower);
            newBullet.gameObject.GetComponent<BulletLogic>().SetPierce(bulletsPierce);
            newBullet.gameObject.GetComponent<BulletLogic>().SetDirection(pos - center);
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
