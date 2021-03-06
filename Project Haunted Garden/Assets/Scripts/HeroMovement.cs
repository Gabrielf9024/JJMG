﻿using System.Collections;
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
    public bool rawInputOn = true;

    private float xInput = 0;
    private float yInput = 0;

    void Start()
    {
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
    }






}
