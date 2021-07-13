using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemyhealth : MonoBehaviour
{
    //UI Elements
    public Slider playerHealthIndicator;
    float sliderActiveTime=0;
    public float maxHealth;

 
    float currentHealth;
    public GameObject deathPS;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthIndicator.maxValue = maxHealth;
        currentHealth = maxHealth;
        playerHealthIndicator.value = maxHealth;
        playerHealthIndicator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sliderActiveTime < Time.time)
        {
            playerHealthIndicator.gameObject.SetActive(false);
        }
        
    }
    public void addDamage(float damage)
    {
        currentHealth -= damage;
        playerHealthIndicator.gameObject.SetActive(true);
        sliderActiveTime = Time.time + 2f;
        playerHealthIndicator.value = currentHealth;
        if (currentHealth <= 0)
        {
           
            Instantiate(deathPS, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
   
}
