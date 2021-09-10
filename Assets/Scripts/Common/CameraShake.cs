using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration;
    public float magnitude;

    GameObject mainCamera;
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    public void Shake()
    {
        StartCoroutine(ShakeCR());
    }
    IEnumerator ShakeCR()
    {
        Vector3 origPos = mainCamera.transform.position;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(0f, 1f) * magnitude;
            float y = Random.Range(0f, 1f) * magnitude;
            Vector3 pos = mainCamera.transform.position;
            pos = new Vector3(pos.x + x, pos.y + y,pos.z);
            mainCamera.transform.position = pos;
            elapsed += Time.deltaTime;
            yield return null;
       }
        mainCamera.transform.position = origPos;
    }

}
