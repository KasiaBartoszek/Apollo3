using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachToCameraGunStatic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
    }

    float iter = 0;
    float lastY = 0;
    float lastZ = 0;

    public GameObject go;
    float effectStrength = 0.02f;
    void LateUpdate()
    {
        iter += Time.deltaTime;
        go.transform.Translate(-lastY, 0, -lastZ);

        lastY = Mathf.Sin(iter) * effectStrength;
        lastZ = Mathf.Cos(iter) * effectStrength;
        go.transform.Translate(lastY, 0, lastZ);

        //attach Game Object go to target
        //Transform target = Camera.main.transform;
        //go.transform.parent = target;
        //go.transform.
    }
}
