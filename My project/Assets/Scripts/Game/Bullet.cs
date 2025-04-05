using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5f;        
    public float speed = 5f;          
    public float destroyXLimit = 30f;  
    [SerializeField] private Score_LifeDataSO ScoreRef;
    public SelectedShipDataSO selectedShipData;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        if (rb != null)
        {
            rb.linearVelocity = Vector2.right * speed; 
        }

        Destroy(gameObject, lifetime); 
    }

    void Update()
    {
        if (transform.position.x > destroyXLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);  
            Destroy(gameObject); 
            ScoreRef.AddPoints((int)selectedShipData.selectedShip.scoreSpeed);
        }
    }
}
