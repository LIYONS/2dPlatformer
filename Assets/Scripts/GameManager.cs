using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay;
    bool canRestart = false;
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
}
