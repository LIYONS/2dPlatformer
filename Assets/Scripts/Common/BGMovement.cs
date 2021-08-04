using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour
{
    float offsetX;
    public Transform player;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        offsetX = transform.position.x - player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            pos = transform.position;
            pos.x = player.position.x + offsetX;
            transform.position = pos;
        }
    }
}
