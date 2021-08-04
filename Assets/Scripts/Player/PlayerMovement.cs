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

    public bool facingRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = true;
    }
    private void Update()
    { 
        //Jump
        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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
        }
    }
    IEnumerator AnimTimeControl()
    {
        yield return new WaitForSeconds(.5f);
        anim.SetBool("isAttacking",false);
    }      
}
