using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetFloat("lastPosX", other.transform.position.x);
            PlayerPrefs.SetFloat("lastPosY", other.transform.position.y);
            PlayerPrefs.Save();
        }
    }
}
