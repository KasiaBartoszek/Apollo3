using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSettingsScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject projectile;
    public float fireDelta = 0.5F;

    private float nextFire = 0.5F;
    private GameObject newProjectile;
    private float myTime = 0.0F;

    // https://docs.unity3d.com/ScriptReference/Input.GetButton.html
    // https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html
    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("c") && myTime > nextFire)
        {


            nextFire = myTime + fireDelta;
            //newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            
            // create code here that animates the newProjectile
            
            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }
}
