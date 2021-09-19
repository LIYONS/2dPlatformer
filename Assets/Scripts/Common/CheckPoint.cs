using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public SpriteRenderer locIcon;
    private void Start()
    {
        locIcon.color = Color.black;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            locIcon.color = Color.red;
            PlayerPrefs.SetFloat("lastPosX", other.transform.position.x);
            PlayerPrefs.SetFloat("lastPosY", other.transform.position.y);
            PlayerPrefs.Save();
        }
    }
}
