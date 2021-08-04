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
    bool isAgro=false;
    Transform player;
    private void Start()
    {
        cannonAnimator = GetComponentInChildren<Animator>();
        shootInterval = Time.time;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    private void Update()
    {
        if (isAgro)
        {
            transform.up = player.position - transform.position;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (shootInterval < Time.time && other.tag=="Player")
        {
            isAgro = true;
            
            //transform.LookAt(other.transform);
            //Vector3 dir = other.gameObject.transform.position- transform.position;
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(spore, cannonTip.position, Quaternion.identity);
            shootInterval =Time.time+ offset;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isAgro = false;
        }
    }
}
