using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeMovement : MonoBehaviour
{
    public GameObject leafPS;
    public Rigidbody2D sporeRb;
    public float forceLow;
    public float forceHigh;
    public float torqueAmount;

    void Start()
    {
        sporeRb.AddForce(new Vector2(Random.Range(forceLow,forceHigh), Random.Range(forceLow,forceHigh)), ForceMode2D.Impulse);
        sporeRb.AddTorque(torqueAmount);
        Instantiate(leafPS, transform.position, Quaternion.identity);

    }

}
