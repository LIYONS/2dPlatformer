using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float damage;

    public float damageOffset;

     float nextAttackInterval;

    public float pushBackForce;
    // Start is called before the first frame update
    void Start()
    {
        nextAttackInterval = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player" && nextAttackInterval < Time.time)
        {
           PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            player.addDamage(damage);
            nextAttackInterval = Time.time + damageOffset;

            PushBack(collision.gameObject.GetComponent<Rigidbody2D>()) ;

        }
    }
    void PushBack(Rigidbody2D player)
    {
        player.AddForce(new Vector2(pushBackForce, pushBackForce),ForceMode2D.Impulse);
    }
}
