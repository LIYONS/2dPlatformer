using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour
{
    public float damage;

    public GameObject explosion;

    Projectilemovement projectileCtrl;

    // Start is called before the first frame update
    void Start()
    {
        projectileCtrl = GetComponentInParent<Projectilemovement>();

    }

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable")){
            if (projectileCtrl == null)
            {
                projectileCtrl = GetComponentInParent<Projectilemovement>();
            }
            projectileCtrl.removeForce();
            if(collision.tag == "Enemy")
            {
                Enemyhealth enemyhealth = collision.gameObject.GetComponent<Enemyhealth>();
                enemyhealth.addDamage(damage);

            }
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
       
    }
}
