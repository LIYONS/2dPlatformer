using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    float offSetX;
    float offsetY;
    public float lowY = -14;
    Vector3 pos;
    public float smoothening;
 
    void Start()
    {
        offSetX = player.position.x - transform.position.x;
        offsetY = player.position.y - transform.position.y;

    }
    void Update()
    {
        if (player)
        {
            if (player.position.y > lowY)
            {
                pos = transform.position;
                pos.x = player.position.x - offSetX;
                pos.y = player.position.y - offsetY;
                transform.position = pos;
            }
        }

    }
   
}

