using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int completed = PlayerPrefs.GetInt("levelsCompleted");
            if (completed < PlayerPrefs.GetInt("noOfLevels", 0))
            {
                completed++;
                PlayerPrefs.SetInt("levelsCompleted", completed);
            }
            int levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);
            if (levelsUnlocked >= 1 && levelsUnlocked <= PlayerPrefs.GetInt("noOflevels", 3))
            {
                levelsUnlocked++;
                if (PlayerPrefs.GetInt("nextLevel") < PlayerPrefs.GetInt("noOfLevels"))
                {
                    PlayerPrefs.SetInt("nextLevel", (SceneManager.GetActiveScene().buildIndex) + 1);
                }
                PlayerPrefs.SetInt("levelsUnlocked", levelsUnlocked);
            }


            PlayerHealth playerScript = other.gameObject.GetComponent<PlayerHealth>();
            playerScript.WinGame();
        }
    }
}
