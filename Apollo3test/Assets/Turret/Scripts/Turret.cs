using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private bool isPlayerInRange;
    private bool isShotReady = true;
    private GameObject target;

    /// <summary>
    /// Defines how fast the turret can rotate towards player.
    /// Added to turret's barrel rotation once per frame.
    /// </summary>
    public float RotationAngularSpeed;

    /// <summary>
    /// Maximum angular offset, that the gun will shoot at the player.
    /// Sori for bad inglisz.
    /// </summary>
    public float ShootingAngle;

    /// <summary>
    /// Reference to turrets shooting part.
    /// </summary>
    public GameObject TurretGun;

    /// <summary>
    /// Projectile prefab that the gun shoots with.
    /// </summary>
    public GameObject Projectile;

    /// <summary>
    /// Representation of projectile spawn point.
    /// </summary>
    public GameObject ProjectileSpawnPoint;

    /// <summary>
    /// Firing speed.
    /// </summary>
    public float FiringSpeed;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            RotateTowardsPlayer();

            if (IsInAngularScope() && isShotReady)
            {
                Shoot();
            }

            isPlayerInRange = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.gameObject;
            isPlayerInRange = true;
        }
    }

    private void RotateTowardsPlayer()
    {
        var direction = target.transform.position - TurretGun.transform.position;
        direction.Normalize();

        TurretGun.transform.rotation = Quaternion.Slerp(TurretGun.transform.rotation, Quaternion.LookRotation(direction), RotationAngularSpeed * Time.deltaTime);
    }

    private bool IsInAngularScope()
    {
        var angle = Vector3.Angle(TurretGun.transform.forward, target.transform.position - TurretGun.transform.position);
        print(angle);
        return angle < ShootingAngle;
    }

    private void Shoot()
    {
        Transform projectile = Instantiate(Projectile.transform, ProjectileSpawnPoint.transform.position, Quaternion.identity);
        projectile.rotation = ProjectileSpawnPoint.transform.rotation;
        isShotReady = false;
        StartCoroutine(ShootingRate());
    }

    IEnumerator ShootingRate()
    {
        yield return new WaitForSeconds(FiringSpeed);
        isShotReady = true;
    }
}
