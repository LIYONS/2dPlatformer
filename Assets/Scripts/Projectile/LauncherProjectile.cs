using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerHealth plyrHealth;
    public float damage;
    public float speed;
    public GameObject explosionPS; 
    float delay = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
    }
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"&&delay<Time.time)
        {
            rb.velocity = new Vector2(0, 0);
            Instantiate(explosionPS,transform.position, Quaternion.identity);
            plyrHealth = other.gameObject.GetComponent<PlayerHealth>();
            plyrHealth.addDamage(damage);
            delay = Time.time + 1;
            Destroy(gameObject);

        }
    }
}
