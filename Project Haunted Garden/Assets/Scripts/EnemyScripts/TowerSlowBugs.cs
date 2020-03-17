using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSlowBugs : MonoBehaviour
{
    public float slowSpeed;
    private float previousSpeed;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("stay");
            previousSpeed = other.gameObject.GetComponent<EnemyMovement>().speed;
            other.gameObject.GetComponent<EnemyMovement>().SetSpeed(previousSpeed * slowSpeed);
        }
    }
    public void OnTriggerStay2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("stay1");
            other.gameObject.GetComponent<EnemyMovement>().SetSpeed(previousSpeed * slowSpeed);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("stay1");
            other.gameObject.GetComponent<EnemyMovement>().SetSpeed(previousSpeed);
        }
    }
}
