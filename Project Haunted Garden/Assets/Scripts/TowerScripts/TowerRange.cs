using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRange : MonoBehaviour
{
    public int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<Movable>().pickedUp)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            if (GetComponentInParent<Movable>().canBeDropped)
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .45f);
            else
                GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, .45f);
        }
        else
            GetComponent<SpriteRenderer>().enabled = false;

        if (enemyCount == 0)
            transform.parent.GetComponentInChildren<TowerShoot>().seesTarget = false;
        else
            transform.parent.GetComponentInChildren<TowerShoot>().seesTarget = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            ++enemyCount;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            --enemyCount;
    }
}
