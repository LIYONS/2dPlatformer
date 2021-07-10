using System.Collections;
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
    public float jumpDistance;
    public Transform centerPoint;
    float radius = 0.2f;
    public LayerMask groundLayer;

    //shooting
    public Transform gunTip;
    public GameObject bullet;
    public float fireRate = 1f;
    float nextFire;


    SpriteRenderer playerSprite;

    public bool facingRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        facingRight = true;
    }


    public void flipPlayer()
    {
        facingRight = !facingRight;
        jumpDistance *= -1;
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
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            anim.SetBool("isgrounded", false);
            rb.AddForce(new Vector2(jumpDistance, jumpheight));
        }

        //Shoot
        if(isGrounded && Input.GetAxisRaw("Fire1")>0)
        {
            Fire();
        }
      
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(h));

        Vector2 pos = transform.position;
        if (isGrounded) pos.x += h * speed * Time.deltaTime;

        else
            pos.x += h * speed *.3f* Time.deltaTime;
        



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
