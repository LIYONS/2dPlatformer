
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Audio
    public AudioSource playerHurt;

    //UI Elements
    public Slider playerHealthIndicator;

    public float maxHealth;
    float currentHealth;
    public GameObject bloodPS;
    public GameObject damageTaken;

    float sliderActiveTime=0f;
    private void Start()
    {
        playerHealthIndicator.maxValue = maxHealth;
        currentHealth = maxHealth;
        playerHealthIndicator.value = maxHealth;
        playerHealthIndicator.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (sliderActiveTime < Time.time)
        {
            playerHealthIndicator.gameObject.SetActive(false);
        }
    }
    public void addDamage(float damage)
    { 
        sliderActiveTime = Time.time+1f;
        currentHealth -= damage;
        playerHurt.Play();
        playerHealthIndicator.gameObject.SetActive(true);
        playerHealthIndicator.value = currentHealth;
        Instantiate(damageTaken, transform.position, transform.rotation);
        if (currentHealth <= 0)
        {
            kill();
        }   
        
    }
    public void kill()
    {
        if (currentHealth <= 0)
        {
            Instantiate(bloodPS, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
   
}
