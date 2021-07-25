using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    float offSet;
    float lowY;
    Vector3 pos;

    void Start()
    {
        StartCoroutine(CollectPos());
        offSet = player.position.x - transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            if (player.position.y > lowY)
            {
                pos = transform.position;
                pos.x = player.position.x - offSet;
                transform.position = pos;
            }
        }

    }
    IEnumerator CollectPos()
    {
        yield return new WaitForSeconds(1f);
        lowY = player.position.y-0.5f;
    }
}

