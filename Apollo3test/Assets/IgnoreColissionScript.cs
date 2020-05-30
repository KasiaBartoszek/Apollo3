using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColissionScript : MonoBehaviour
{

    public Collider gameObject0;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(gameObject0, GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
