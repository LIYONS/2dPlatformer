
using UnityEngine;

using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    //UI Elements
    public Slider playerHealthIndicator;

    public float maxHealth;
    float currentHealth;
    public GameObject bloodPS;
    public GameObject damageTaken;
    private void Start()
    {
        playerHealthIndicator.maxValue = maxHealth;
        currentHealth = maxHealth;
    }
    public void addDamage(float damage)
    {
        currentHealth -= damage;
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
