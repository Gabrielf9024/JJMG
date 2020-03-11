using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRange : MonoBehaviour
{
    public int enemyCount = 0;

    SpriteRenderer rangeIndicator;
    // Start is called before the first frame update
    void Start()
    {
        rangeIndicator = GetComponent<SpriteRenderer>();
        rangeIndicator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<Movable>().pickedUp)
        {
            rangeIndicator.enabled = true;

            if (GetComponentInParent<Movable>().canBeDropped)
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .45f);
            else
                GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, .45f);
        }

        if (enemyCount == 0)
            transform.parent.GetComponentInChildren<TowerShoot>().seesTarget = false;
        else
            transform.parent.GetComponentInChildren<TowerShoot>().seesTarget = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            ++enemyCount;
        if(collision.CompareTag("Hand"))
            rangeIndicator.enabled = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            --enemyCount;
        if(collision.CompareTag("Hand"))
            rangeIndicator.enabled = false;

    }
}
