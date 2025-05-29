using UnityEngine;

public class SmallAsteroid : MonoBehaviour
{
    public float lifeTime = 4f;
    public int scoreValue = 10;

    void Start()
    {
        Destroy(gameObject, lifeTime);
        if (GetComponent<Rigidbody2D>() == null)
        {
            Debug.LogError("SmallAsteroid requires a Rigidbody2D component!", this);
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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}