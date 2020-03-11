using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTowerRange : MonoBehaviour
{
    public List<GameObject> CollidedWith;
    private int size;
    public GameObject FocusObj;
    private int NumMax;
    SpriteRenderer rangeIndicator;

    // Start is called before the first frame update
    void Start()
    {
        rangeIndicator = GetComponent<SpriteRenderer>();
        rangeIndicator.enabled = false;

        size = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<Movable>().pickedUp)
        {
            rangeIndicator.enabled = true;

            if (GetComponentInParent<Movable>().canBeDropped)
                rangeIndicator.color = new Color(255, 255, 255, .45f);
            else
                rangeIndicator.color = new Color(255, 0, 0, .45f);
        }

        if( CollidedWith.Count == 0 )
            gameObject.transform.parent.GetComponentInChildren<SeekTowerLogic>().seesTarget = false;

        else
            gameObject.transform.parent.GetComponentInChildren<SeekTowerLogic>().seesTarget = true;


        FindMaxWP();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            size++;
            CollidedWith.Add(collision.gameObject);
        }
        if (collision.CompareTag("Hand"))
            rangeIndicator.enabled = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            CollidedWith.Remove(collision.gameObject);
            size--;
            FindMaxWP();
        }
        if (collision.CompareTag("Hand"))
            rangeIndicator.enabled = false;
    }
    public void FindMaxWP() //Targets the enemy that is farthest down the path
    {
        NumMax = -1;
        int future = 0;
        if (size > 0)
        {
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
        else
            gameObject.transform.parent.GetComponentInChildren<SeekTowerLogic>().focus = null;
    }
}
