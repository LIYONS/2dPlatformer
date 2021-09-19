using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string lifeC = "lifeCount", lastX = "lastPosX",lastY="lastPosY",levelsUnlock="levelsUnlocked";
    

    void Update()
    {      
        if (Input.GetKey("escape")) Application.Quit();      
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StartOver()
    {
        if (PlayerPrefs.HasKey(lifeC))
        {
            PlayerPrefs.DeleteKey(lifeC);
            PlayerPrefs.DeleteKey(lastX);
            PlayerPrefs.DeleteKey(lastY);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        PlayerPrefs.DeleteKey(lifeC);
        PlayerPrefs.DeleteKey(lastX);
        PlayerPrefs.DeleteKey(lastY);
        Application.Quit();
    }
    public void nextLevel()
    {
        int levelsUnlocked = PlayerPrefs.GetInt(levelsUnlock, 1);
        if (levelsUnlocked >= 1 && levelsUnlocked <= PlayerPrefs.GetInt("noOflevels",3))
        {
            levelsUnlocked++;
            PlayerPrefs.SetInt("levelsUnlocked", levelsUnlocked);
        }


        PlayerPrefs.DeleteKey(lifeC);
        PlayerPrefs.DeleteKey(lastX);
        PlayerPrefs.DeleteKey(lastY);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void selectLevel(int bIndex)
    {
        if (PlayerPrefs.HasKey(lifeC )| PlayerPrefs.HasKey(lastX))
        {
            PlayerPrefs.DeleteKey(lifeC);
            PlayerPrefs.DeleteKey(lastX);
            PlayerPrefs.DeleteKey(lastY);
        }
        SceneManager.LoadScene(bIndex);
    }
    public void AutoPlaying()
    {
        int nextSceneBI = PlayerPrefs.GetInt("nextLevel",2);
        SceneManager.LoadScene(nextSceneBI);
    }
}


