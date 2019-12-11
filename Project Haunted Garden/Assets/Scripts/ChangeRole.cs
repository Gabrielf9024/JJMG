using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRole : MonoBehaviour
{

    private Transform target;
    private Transform myself;
    private Rigidbody2D myBody;

    public float Minrange;
    public float Maxrange;
    public float stop;

    private Vector2 move;
    // Start is called before the first frame update

    public void switchToSeek()
    {
        GetComponentInParent<PathEnemy>().enabled = false;
        GetComponentInParent<SeekerEnemy>().enabled = true;
    }
    public void switchToPath()
    {
        GetComponentInParent<PathEnemy>().enabled = true;
        GetComponentInParent<SeekerEnemy>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 direction = (this.transform.position - collision.transform.position).normalized;
            collision.gameObject.GetComponent<HeroHealth>().ouch(direction);
            GetComponentInParent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            switchToPath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switchToSeek();
        }
    }
}
