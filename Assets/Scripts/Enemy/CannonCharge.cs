using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCharge : MonoBehaviour
{
    Animator cannonAnimator;
    public GameObject spore;
    public Transform cannonTip;
    private float shootInterval;
    public float offset;
    private void Start()
    {
        cannonAnimator = GetComponentInChildren<Animator>();
        shootInterval = 0f;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (shootInterval < Time.time && other.tag=="Player")
        {
            Instantiate(spore, cannonTip.position, Quaternion.identity);
            shootInterval += offset;
        }
        
    }
}
