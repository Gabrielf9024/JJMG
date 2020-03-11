using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatRange : MonoBehaviour
{

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
                rangeIndicator.color = new Color(255, 255, 255, .45f);
            else
                rangeIndicator.color = new Color(255, 0, 0, .45f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hand"))
            rangeIndicator.enabled = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hand"))
            rangeIndicator.enabled = false;

    }
}
