using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 2f;
    public float dropSpeed = 0.5f;
    public float bottomY = -4.5f;
    public string deathSceneName = "Death";

    private Vector2 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        MoveEnemy();
        CheckGameOver();
    }

    void MoveEnemy()
    {
        float moveDirection = movingRight ? 1 : -1;
        transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            movingRight = !movingRight;
            transform.Translate(Vector3.down * dropSpeed);
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
