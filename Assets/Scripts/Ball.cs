using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float speed = 5f;

    public float lifeTime = 3f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * speed;
        }

        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Shooting shooting = other.GetComponent<Shooting>();
            if (shooting != null)
            {
                shooting.ActivateBonus();
            }
        }
    }
}
