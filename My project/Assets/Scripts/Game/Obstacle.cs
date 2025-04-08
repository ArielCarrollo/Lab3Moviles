using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damageAmount = 10;
    public float moveSpeed = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damageAmount);
            Debug.Log("Jugador tocado por enemigo.");
        }
        else if (collision.gameObject.CompareTag("Boundary"))
        {
            ObstaclePool.Instance.ReturnObstacle(gameObject);
        }
    }
}
