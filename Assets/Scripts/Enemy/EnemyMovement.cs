using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Flipping

    Rigidbody2D boarRBody;
    bool ifIdle = true;
    bool facingRight = false;
    //float nextFliptime=0;

    //Attack
    Animator boarAnimator;
    float attackOffset;
    public float attackSpeed;
    public float zombieSpeed;
    public Transform edgeDetecObj;
    RaycastHit2D groundInfo;
    bool isGrounded = true;
    public LayerMask ground;
    Vector3 pos;
    float nextDetection=0f;
    
    void Start()
    {
        
        boarRBody = GetComponent<Rigidbody2D>();
        boarAnimator = GetComponentInChildren<Animator>();
        pos = transform.position;
    }

    void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>())
        {

            if (ifIdle && transform.position.y>= (pos.y-1f))
            { 
                if (facingRight)
                {
                    boarRBody.velocity = new Vector2(zombieSpeed, 0);
                }
                else 
                {
                    boarRBody.velocity = new Vector2(-zombieSpeed, 0);
                }
            }

            
            isGrounded= Physics2D.OverlapCircle(edgeDetecObj.position,.1f,ground);
            if (isGrounded==false && nextDetection<Time.time )
            {
                nextDetection = Time.time + 1f;
                boarRBody.velocity = Vector2.zero;
                FlipEnemy();
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {           
            ifIdle = false;
            attackOffset = Time.time + .5f;
            if(facingRight && boarRBody.transform.position.x > other.transform.position.x)
            {
                FlipEnemy();
            }
            if(!facingRight && boarRBody.transform.position.x < other.transform.position.x)
            {
                FlipEnemy();
            }
        }    
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (attackOffset < Time.time && other.tag=="Player")
        {
            
            if(boarAnimator)
            boarAnimator.SetBool("IsCharged", true);
            if(facingRight)
                boarRBody.velocity=(new Vector2(attackSpeed, 0));
            else
                boarRBody.velocity=(new Vector2(-attackSpeed, 0));
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        { 
            ifIdle = true;
            boarRBody.velocity = new Vector2(0, 0);
            if(boarAnimator) boarAnimator.SetBool("IsCharged", false);
        }
    }
    void FlipEnemy()
    {
        facingRight = !facingRight;
        boarRBody.transform.localScale = new Vector3(boarRBody.transform.localScale.x * -1, boarRBody.transform.localScale.y, boarRBody.transform.localScale.z);
    }
 
}
