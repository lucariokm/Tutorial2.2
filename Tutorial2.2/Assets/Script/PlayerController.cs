﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent <Rigidbody2D> ();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
     Application.Quit();
    }

    void FixedUpdate()
    {
        float moveHorizontal= Input.GetAxis ("Horizontal");
        Vector2 movement = new Vector2 (moveHorizontal,0);
        rb.AddForce (movement * speed);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if(Input.GetKey (KeyCode.UpArrow))
            {
                rb.AddForce (new Vector2(0,jumpForce), ForceMode2D.Impulse);     
            }
        }
    }
}
