using UnityEngine;

public class LauncherControl : MonoBehaviour
{
    public float nextShotDelay;
    float nextShot;
    public Transform gunTip;
    public GameObject bullet;
    public GameObject puffPS;
    void Update()
    {
        if (nextShot< Time.time)
        {
            Instantiate(bullet, gunTip.position, bullet.transform.rotation);
            Instantiate(puffPS, gunTip.position,Quaternion.identity);
            nextShot = Time.time + nextShotDelay;
        }
        
    }
}
