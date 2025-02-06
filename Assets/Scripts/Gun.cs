using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera fpsCam; // Reference to player's camera
    public float range = 100f; // How far the bullets can hit
    public float damage = 20f; // Damage per shot
    public GameObject impactEffect; // Particle effect for bullet impact

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left Mouse Button
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            // Apply damage if the object has an EnemyHealth component
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Create an impact effect where the bullet hits
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
