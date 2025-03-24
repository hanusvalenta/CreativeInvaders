using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2Movement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 2f;
    public float dropSpeed = 0.5f;
    public float bottomY = -4.5f;
    public string deathSceneName = "Death";

    public GameObject projectilePrefab;
    public float shootInterval = 2f;
    public float projectileSpeed = 5f;

    private Vector2 startPos;
    private bool movingRight = true;
    private float nextShootTime;

    void Start()
    {
        startPos = transform.position;
        nextShootTime = Time.time + shootInterval;
    }

    void Update()
    {
        MoveEnemy();
        CheckGameOver();
        Shoot();
    }

    void MoveEnemy()
    {
        float moveDirection = movingRight ? 1 : -1;
        transform.position += Vector3.right * moveDirection * moveSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            movingRight = !movingRight;
            transform.position += Vector3.down * dropSpeed;
        }
    }

    void Shoot()
    {
        if (Time.time >= nextShootTime)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            nextShootTime = Time.time + Random.Range(1f, 10f);
        }
    }

    void CheckGameOver()
    {
        if (transform.position.y <= bottomY)
        {
            SceneManager.LoadScene(deathSceneName);
        }
    }
}
