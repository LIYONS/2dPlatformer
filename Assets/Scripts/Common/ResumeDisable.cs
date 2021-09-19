using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ResumeDisable : MonoBehaviour
{
    public GameObject  resume;
    private void Start()
    {
        if (PlayerPrefs.HasKey("lifeCount") != true)
        {
            resume.SetActive(false);
        }
    }
}
