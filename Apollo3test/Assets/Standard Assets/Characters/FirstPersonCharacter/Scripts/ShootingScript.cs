using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class ShootingScript : MonoBehaviour
{

    public Rigidbody projectile;
    public GameObject firstPersonController;
    public RigidbodyFirstPersonController controller;

    public float speed = 20;
    public float knockbackSpeed = 1;
    public float destroyTime = 1;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile,
                                                           transform.position,
                                                           transform.rotation)
                as Rigidbody;

            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
            Object.Destroy(instantiatedProjectile.gameObject, destroyTime);

            controller.apollo_knockback_add(transform.TransformDirection(new Vector3(0, 0, -knockbackSpeed)));
        }
    }

}