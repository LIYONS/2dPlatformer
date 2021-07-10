using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{

    public float maxHealth;

    float currentHealth;
    public GameObject bloodPS;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Instantiate(bloodPS, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
