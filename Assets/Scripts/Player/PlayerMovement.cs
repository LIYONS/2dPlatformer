using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2;
    Rigidbody2D rb;
    Animator anim;

    //Jumping variables
    bool isGrounded = false;
    public float jumpForce;
    public Transform centerPoint;
    float radius = 0.2f;
    public LayerMask groundLayer;

    //shooting
    public Transform gunTip;
    public GameObject bullet;
    public float fireRate = 1f;
    float nextFire;
    CameraShake camShake;

    //Sliding
    public Transform frontTouch;
    bool isTouchingFront;
    bool wallSliding;

    //wallJump
    public float xWallForce;
    public float yWallForce;


    public bool facingRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = true;
        camShake = GetComponent<CameraShake>();
    }
    private void Update()
    { 
        //Jump
        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        //wallJump
        if (wallSliding && Input.GetKeyDown("space"))
        {
            rb.AddForce(new Vector2(-xWallForce,yWallForce),ForceMode2D.Impulse);
        }
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
        isGrounded = Physics2D.OverlapCircle(centerPoint.position, radius, groundLayer);
        anim.SetBool("isgrounded", isGrounded);

        anim.SetFloat("verticalSpeed", rb.velocity.y);

       

        //Shoot
        if(Input.GetAxisRaw("Fire1")>0)
        {
            Fire();
            
        }
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(h));
        if (h!=0)
        {
            if(!wallSliding)
            rb.velocity = new Vector2(h * speed, rb.velocity.y);

            
            if (h > 0 && facingRight != true)
            {
                flipPlayer();
            }
            else if (h < 0 && facingRight)
            {
                flipPlayer();
            }
        }
        //Slide
        isTouchingFront = Physics2D.OverlapCircle(frontTouch.position, 0.2f,groundLayer);
        if (isTouchingFront && isGrounded==false && h != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }
        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y,0,float.MaxValue));
        }
    }
    public void Fire()
    {
        if (Time.time > nextFire)
        {
            anim.SetBool("isAttacking",true);
            StartCoroutine(AnimTimeControl());
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                
            }
            camShake.Shake();
        }
    }
    IEnumerator AnimTimeControl()
    {
        yield return new WaitForSeconds(.5f);
        anim.SetBool("isAttacking",false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(centerPoint.position,.2f);
        Gizmos.DrawSphere(frontTouch.position, .2f);
    }
}
