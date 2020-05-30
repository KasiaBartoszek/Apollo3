using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movinglight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float iter = 0;
    float lastY = 0;
    float lastX = 0;
    float lastZ = 0;

    public GameObject go;
    public float speed = 1.0f;
    public float effectStrength = 10f;
    void LateUpdate()
    {
        iter += Time.deltaTime * speed;
        go.transform.Translate(-lastX, -lastY, -lastZ);

        lastY = Mathf.Sin(iter) * effectStrength;
        lastZ = Mathf.Cos(iter) * effectStrength;
        lastX = Mathf.Cos(iter) * effectStrength;
        go.transform.Translate(lastX, lastY, lastZ);

    }
}
