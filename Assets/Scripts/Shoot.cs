using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public float fireRate = 0.2f;

    private float nextFireTime = 0f;
    
    public AudioClip Beep;
    
    public float BeepVolume = 0.5f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            if (Beep != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = Beep;
            audioSource.volume = BeepVolume;
            audioSource.Play();
        } 
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null || firePoint == null) return;

        Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position).normalized;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }
}
