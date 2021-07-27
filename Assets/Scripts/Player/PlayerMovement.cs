﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2;
    Rigidbody2D rb;
    Animator anim;

    //Jumping variables
    bool isGrounded = false;
    public float jumpheight;
    public Transform centerPoint;
    float radius = 0.2f;
    public LayerMask groundLayer;
    float nextJump;

    //shooting
    public Transform gunTip;
    public GameObject bullet;
    public float fireRate = 1f;
    float nextFire;

    public bool facingRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        facingRight = true;
        nextJump = 0f;
    }


    public void flipPlayer()
    {
        facingRight = !facingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    void FixedUpdate()
    {
        //isgrounded?
        isGrounded = Physics2D.OverlapCircle(centerPoint.position,radius, groundLayer);
        anim.SetBool("isgrounded", isGrounded);

        anim.SetFloat("verticalSpeed", rb.velocity.y);

        //Jump
        if (isGrounded && Input.GetAxis("Jump") > 0 && nextJump<Time.time)
        {
            
            anim.SetBool("isgrounded", false);
            rb.AddForce(new Vector2(0, jumpheight));
            nextJump =Time.time+.7f;
        }

        //Shoot
        if(isGrounded && Input.GetAxisRaw("Fire1")>0)
        {
            Fire();
        }
      
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(h));

        Vector2 pos = transform.position;
        if(isGrounded) pos.x += h * speed * Time.deltaTime;
        else pos.x += h * speed*.5f * Time.deltaTime;







        transform.position = pos;

        if(h>0 && facingRight !=true)
        {
            flipPlayer();
        }
        else if(h<0 && facingRight)
        {
            flipPlayer();
        }

    }
    void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                
            }
        }
        

       

    }
}
