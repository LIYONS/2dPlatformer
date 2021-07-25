using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealth playerScript = other.gameObject.GetComponent<PlayerHealth>();
            playerScript.WinGame();
        }
    }
}
