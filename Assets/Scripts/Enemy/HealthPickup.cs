using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    public float healthAmount;

    float lifeTime;
    public float aliveTime;

    private void Start()
    {
       lifeTime = Time.time + aliveTime;
    }
    private void Update()
    {
        if (lifeTime < Time.time) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            PlayerHealth healthScript = other.gameObject.GetComponent<PlayerHealth>();
            healthScript.addHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
