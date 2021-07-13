using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Flipping

    Rigidbody2D boarRBody;
    bool canFlip = true;
    bool facingRight = false;
    float nextFliptime=0;

    //Attack
    Animator boarAnimator;
    float attackOffset;
    public float attackSpeed;
    
    void Start()
    {
        
        boarRBody = GetComponentInChildren<Rigidbody2D>();
        boarAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (GetComponentInChildren<Rigidbody2D>())
        {
            if ((nextFliptime < Time.time) && canFlip)
            {

                if (Random.Range(0, 20) < 5)
                {
                    FlipEnemy();
                    nextFliptime = Time.time + 4f;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = false;
            attackOffset = Time.time + 1f;
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
            canFlip = true;
            boarRBody.velocity = new Vector2(0, 0);
            boarAnimator.SetBool("IsCharged", false);
        }
    }
    void FlipEnemy()
    {
        facingRight = !facingRight;
        boarRBody.transform.localScale = new Vector3(boarRBody.transform.localScale.x * -1, boarRBody.transform.localScale.y, boarRBody.transform.localScale.z);
    }
}
