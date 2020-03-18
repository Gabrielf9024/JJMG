using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{

    [Header("Movement Stats")]
    [SerializeField] float speed = 5f;

    private Rigidbody2D rb;

    string horizontalControl;
    string verticalControl;

    public string shootControl;
    public string waterControl;
    public bool rawInputOn = true;

    private float xInput = 0;
    private float yInput = 0;

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        horizontalControl = "Horizontal";
        verticalControl = "Vertical";

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rawInputOn) {
            xInput = Input.GetAxisRaw(horizontalControl);
            yInput = Input.GetAxisRaw(verticalControl);
        }
        else {
            xInput = Input.GetAxis(horizontalControl);
            yInput = Input.GetAxis(verticalControl);
        }

        rb.velocity = new Vector2(xInput * speed, yInput * speed);
        
        if( xInput == 0 )
        {
            if (yInput == 1)
            {
                falseTheAnim();
                anim.SetBool("walkingUp", true);
            }
            else if( yInput == -1 )
            {
                falseTheAnim();
                anim.SetBool("walkingDown", true);
            }
            else
            {
                falseTheAnim();
                anim.SetBool("standing", true);
            }
        }
        else
        {
            if( xInput == 1 )
            {
                falseTheAnim();
                anim.SetBool("walkingRight", true);
            }
            else
            {
                falseTheAnim();
                anim.SetBool("walkingLeft", true);
            }
        }
    }

    private void falseTheAnim()
    {
        foreach (AnimatorControllerParameter parameter in anim.parameters)
        {
            anim.SetBool(parameter.name, false);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("OutOfBounds") )
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }




}
