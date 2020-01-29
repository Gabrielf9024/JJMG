using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamage : MonoBehaviour
{
    public int damage = 1;
    GameObject gm;

    private void Awake()
    {
        gm = GameObject.Find("GameManager");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gm.GetComponent<GameManager>().baseHealth -= damage;
            gm.GetComponent<GameManager>().UpdateUI();
            Destroy(collision.gameObject);
        }
    }

}
