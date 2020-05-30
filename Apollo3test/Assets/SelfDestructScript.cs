using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float selfDestroyTime = 2;

    float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Object.Destroy(this.gameObject, selfDestroyTime);
        if (time > selfDestroyTime)
        {
            Object.Destroy(this.gameObject, selfDestroyTime);
        }
    }
}
