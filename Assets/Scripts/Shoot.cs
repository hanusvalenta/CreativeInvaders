using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject projectileTracingPrefab;

    public GameObject bullet; 

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
        if (bullet == null || firePoint == null) return;

        Instantiate(bullet, firePoint.position, Quaternion.identity);

        GameObject projectile = Instantiate(bullet, firePoint.position, Quaternion.identity);

        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position).normalized;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }

    public void ActivateBonus()
    {
        int bonusNum = Random.Range(1, 4);

        switch (bonusNum)
        {
            case 1:
            Bonus1();
            break;
            case 2:
            Bonus2();
            break;
            case 3:
            Bonus3();
            break;
        }
    }

    void Bonus1()
    {
        StartCoroutine(TemporaryFireRateBoost());

        IEnumerator TemporaryFireRateBoost()
        {
            float originalFireRate = fireRate;
            fireRate = 0f;
            yield return new WaitForSeconds(5f);
            fireRate = originalFireRate;
        }

        Debug.Log("Bonus 1 activated!");
    }
    void Bonus2()
    {
        StartCoroutine(TemporaryTracingBullet());

        IEnumerator TemporaryTracingBullet()
        {
            GameObject originalBullet = bullet;
            bullet = projectileTracingPrefab;
            yield return new WaitForSeconds(5f);
            bullet = originalBullet;
        }

        Debug.Log("Bonus 2 activated!");
    }
    void Bonus3()
    {
        // Implement bonus 3 logic here
        Debug.Log("Bonus 3 activated!");
    }
}
