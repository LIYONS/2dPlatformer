using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObjDestroy : MonoBehaviour
{
     PlayerHealth PlyrHealthScript;
     Enemyhealth EneHealthScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.tag == "Player")
        {
            PlyrHealthScript = other.gameObject.GetComponent<PlayerHealth>();
            PlyrHealthScript.kill();
        }
        else if (other.tag == "Enemy")
        {
            EneHealthScript = other.gameObject.GetComponent<Enemyhealth>();
            EneHealthScript.kill();

        }
        else Destroy(other.gameObject);

    }

}
