using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageAmount = 10;
    public float moveSpeed = 5f;  // Velocidad del enemigo

    private void Start()
    {
        // Inicializar el movimiento hacia la izquierda
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * moveSpeed;  // Mover hacia la izquierda
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damageAmount);
            Debug.Log("Jugador tocado por enemigo.");
        }
    }
}


