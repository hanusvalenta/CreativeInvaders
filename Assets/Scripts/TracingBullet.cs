using UnityEngine;

public class TracingB : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    public GameObject ballPrefab;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector2 direction = (mousePosition - transform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);

            Destroy(gameObject, lifeTime);
        }
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector2 direction = (mousePosition - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ScoreManager.instance.AddScore(50);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
        if (other.CompareTag("Enemy3"))
        {
            GameObject ball = Instantiate(ballPrefab, other.transform.position, Quaternion.identity);
            Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                ballRb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
            }

            ScoreManager.instance.AddScore(50);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
