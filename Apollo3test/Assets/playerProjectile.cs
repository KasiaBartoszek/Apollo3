using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "Player") return;
        Health hp = other.gameObject.GetComponent<Health>();
        if(hp != null)
        {
            hp.takeDamage(damage);
        }
    }
}
