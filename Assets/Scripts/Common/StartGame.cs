using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject gameManager;
    GameManager gameMngScript;
   
    void Start()
    {
        gameMngScript = gameManager.GetComponent<GameManager>();
        StartCoroutine(StartGameA());
        
    }
    IEnumerator StartGameA()
    {
        yield return new WaitForSeconds(4f);
        gameMngScript.nextLevel();
    }
}

