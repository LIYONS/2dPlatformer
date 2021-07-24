
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Audio
    public AudioSource playerHurt;

    //UI Elements
    public Slider playerHealthIndicator;
    public Image fill;
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
        if (sliderActiveTime < Time.time && currentHealth>1/4*currentHealth)
        {
            playerHealthIndicator.gameObject.SetActive(false);
        }
        if (currentHealth < 1 / 2 * maxHealth) fill.color = new Color(1, 0, 0, 1); 
    }
    public void addDamage(float damage)
    {
        if (damage > 0)
        {
            sliderActiveTime = Time.time + 1f;
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
        
    }
    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        playerHealthIndicator.value = currentHealth;
        sliderActiveTime = Time.time + 1f;
        playerHealthIndicator.gameObject.SetActive(true);
        if (currentHealth > maxHealth) currentHealth = maxHealth;
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
