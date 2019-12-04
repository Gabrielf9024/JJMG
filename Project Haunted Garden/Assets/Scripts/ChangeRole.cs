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

    public void switchRoles()
    {
        GetComponentInParent<PathEnemy>().enabled = false;
        GetComponentInParent<SeekerEnemy>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switchRoles();
        }
    }
}
