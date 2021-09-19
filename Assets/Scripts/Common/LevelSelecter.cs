using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelecter : MonoBehaviour
{
    int levelsUnlocked, levelsCompleted;
    public Button[] levelButtons;

    private void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked",1);
        levelsCompleted =PlayerPrefs.GetInt("levelsCompleted", 0);
        PlayerPrefs.SetInt("noOfLevels", levelButtons.Length);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i < levelsUnlocked)
            {
                if (i < levelsCompleted)
                {
                    levelButtons[i].image.color = new Color(20,175,0,255);
                }
            }
            else
            {
                levelButtons[i].interactable = false;
                levelButtons[i].image.color = new Color(100, 100, 100, 255);

            }
        }
    }

}

