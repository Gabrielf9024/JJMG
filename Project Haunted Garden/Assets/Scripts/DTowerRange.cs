using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTowerRange : MonoBehaviour
{
    public List<GameObject> CollidedWith;
    private int size;
    public GameObject FocusObj;
    private int NumMax;

    // Start is called before the first frame update
    void Start()
    {
        size = 0;
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

        FindMaxWP();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            size++;
            CollidedWith.Add(collision.gameObject);
        }
            //gameObject.transform.parent.GetComponentInChildren<TowerShoot>().seesTarget = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            CollidedWith.Remove(collision.gameObject);
            size--;
            gameObject.transform.parent.GetComponentInChildren<SeekTowerLogic>().focus = null;
        }
        //if (collision.gameObject.tag == "Enemy")
        //gameObject.transform.parent.GetComponentInChildren<TowerShoot>().seesTarget = false;
    }
    public void FindMaxWP()
    {
        NumMax = -1;
        int future = 0;
        if (size > 0) {
            foreach (GameObject x in CollidedWith)
            {
                if (x.GetComponent<PathEnemy>())
                {
                    future = x.GetComponent<PathEnemy>().currentWPindex;
                    if (future > NumMax)
                    {
                        NumMax = future;
                        FocusObj = x;
                        gameObject.transform.parent.GetComponentInChildren<SeekTowerLogic>().focus = FocusObj;
                    }
                }
            }
        }
    }
}
