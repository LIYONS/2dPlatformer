
using UnityEngine;

public class Destroyer : MonoBehaviour
{


    public float aliveTime=2f;
   
    void Start()
    {
        Destroy(gameObject, aliveTime);
    }


}
