using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 3f;
    public GameObject smallAsteroidPrefab;
    public int numberOfSmallAsteroids = 3;
    public float spreadAngle = 45f;
    public float smallAsteroidSpeedMultiplier = 1.2f;
    public int scoreValue = 20;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * speed;
        }
        else
        {
            Debug.LogError("Asteroid requires a Rigidbody2D component!", this);
        }

        if (smallAsteroidPrefab == null)
        {
            Debug.LogError("Small Asteroid Prefab is not assigned in the Inspector!", this);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerProjectile>() != null)
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(scoreValue);
            }
            SpawnSmallAsteroids();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void SpawnSmallAsteroids()
    {
        if (smallAsteroidPrefab != null && numberOfSmallAsteroids > 0)
        {
            Vector2 baseDirection = Vector2.down;
            for (int i = 0; i < numberOfSmallAsteroids; i++)
            {
                float angle = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);
                Quaternion rotation = Quaternion.Euler(0, 0, angle);
                Vector2 direction = rotation * baseDirection;
                GameObject smallAsteroid = Instantiate(smallAsteroidPrefab, transform.position, Quaternion.identity);
                Rigidbody2D smallRb = smallAsteroid.GetComponent<Rigidbody2D>();
                if (smallRb != null)
                {
                    smallRb.velocity = direction.normalized * speed * smallAsteroidSpeedMultiplier;
                }
            }
        }
    }
}