using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackStay : MonoBehaviour
{

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            rb.velocity = new Vector2(0, 0);
        }
        
    }
}

