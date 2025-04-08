using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5f;
    public float speed = 5f;
    public float destroyXLimit = 30f;
    [SerializeField] private Score_LifeDataSO ScoreRef;
    public SelectedShipDataSO selectedShipData;

    private Rigidbody2D rb;
    private float currentLifetime;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.right * speed;
        }
        currentLifetime = 0f;
    }

    void Update()
    {
        currentLifetime += Time.deltaTime;

        if (currentLifetime >= lifetime || transform.position.x > destroyXLimit)
        {
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            ObstaclePool.Instance.ReturnObstacle(collision.gameObject);
            BulletPool.Instance.ReturnBullet(gameObject);
            ScoreRef.AddPoints((int)selectedShipData.selectedShip.scoreSpeed);
        }
        if (collision.CompareTag("Boundary"))
        {
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }
}
