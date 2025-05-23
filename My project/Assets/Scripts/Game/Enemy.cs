using UnityEngine;

public class Enemy : MonoBehaviour
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
        else if (collision.gameObject.CompareTag("Boundary")) // A�ade un collider invisible en los l�mites
        {
            EnemyPool.Instance.ReturnEnemy(gameObject);
        }
    }
}


