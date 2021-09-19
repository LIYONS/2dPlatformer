
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    //Audio
    public AudioSource playerAudSource;

    //UI Elements
    public Slider playerHealthIndicator;
    public float maxHealth;


    //Life
    public Image[] lifeImages;
    int lifeCount;

    //DeathUI
    public GameObject gameOverCanvas;
    public GameObject winCanvas;

    //Restart
    public GameObject gameManager;
    GameManager gameMngScript;

    public float currentHealth;
    public GameObject bloodPS;
    public GameObject damageTaken;

    float sliderActiveTime=0f;
    CameraShake camShake;
    private void Start()
    {
        if (PlayerPrefs.HasKey("lifeCount"))
        {
            lifeCount = PlayerPrefs.GetInt("lifeCount");           
        }
        else
        {
            lifeCount = lifeImages.Length;    
        }
        for(int i = 0; i < lifeImages.Length; i++)
        {
            if (i < lifeCount) lifeImages[i].color = Color.red;
            else lifeImages[i].color = Color.black;
        }
        if (PlayerPrefs.HasKey("lastPosX"))
        {
            Vector3 lastPos = new Vector3(PlayerPrefs.GetFloat("lastPosX"), PlayerPrefs.GetFloat("lastPosY"), transform.position.z);
            transform.position = lastPos;
        }
        gameMngScript = gameManager.GetComponent<GameManager>();
        winCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        playerHealthIndicator.maxValue = maxHealth;
        currentHealth = maxHealth;
        playerHealthIndicator.value = maxHealth;
        playerHealthIndicator.gameObject.SetActive(false);
        camShake = GetComponent<CameraShake>();
    }
    private void Update()
    {
        if (sliderActiveTime < Time.time && currentHealth>1/4*currentHealth)
        {
            playerHealthIndicator.gameObject.SetActive(false);
        }
    }
    public void addDamage(float damage)
    {
        if (damage > 0)
        {
            
            sliderActiveTime = Time.time + 1f;
            currentHealth -= damage;
            camShake.Shake();
            playerAudSource.Play();
            playerHealthIndicator.gameObject.SetActive(true);
            playerHealthIndicator.value = currentHealth;
            Vector3 damPos = new Vector3(transform.position.x, transform.position.y, -10);
            Instantiate(damageTaken,damPos, transform.rotation);
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
        if (lifeCount > 1)
        {
            lifeCount--;
            PlayerPrefs.SetInt("lifeCount", lifeCount);
            PlayerPrefs.Save();
        }
        else if (lifeCount == 1)
        {
            PlayerPrefs.DeleteAll();
        }
        Instantiate(bloodPS, transform.position, transform.rotation);
        if (gameOverCanvas) gameOverCanvas.SetActive(true);
        transform.gameObject.SetActive(false);
    }
    public void WinGame()
    {
        Destroy(gameObject);
        if(winCanvas) winCanvas.SetActive(true);       
    }  
    
}
