using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    /// <summary>
    /// Speed of the projectile.
    /// </summary>
    public float ProjectileSpeed;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * ProjectileSpeed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Health hp = other.GetComponent<Health>();
            hp.takeDamage(damage);
        }

        Destroy(gameObject);
    }
}
