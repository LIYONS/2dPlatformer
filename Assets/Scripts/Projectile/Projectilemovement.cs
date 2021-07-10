
using UnityEngine;

public class Projectilemovement : MonoBehaviour
{


    public Rigidbody2D rb;
    public float speed;
    void Start()
    {
        if(transform.rotation.z !=0)
        
             rb.AddForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
        else
            rb.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
    }
    public void removeForce()
    {
        
        rb.velocity = new Vector2(0, 0);
    }
}
