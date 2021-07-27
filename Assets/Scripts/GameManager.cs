using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay;
    bool canRestart = false;
    public float nextSceneDelay;
    bool canLoad = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (canRestart && restartDelay<Time.time)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKey("escape")) Application.Quit();
        if (canLoad&& nextSceneDelay<Time.time)
        {
            
            if (Time.time > nextSceneDelay) LoadNextLevel();
            canLoad = false;
        }
        
    }
    public void restartGame()
    {
        canRestart = true;
        restartDelay = Time.time + 5f;

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void nextLevel()
    {
        canLoad = true;
        nextSceneDelay = Time.time + 5f;
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
