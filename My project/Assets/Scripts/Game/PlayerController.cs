using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 20f;
    public SelectedShipDataSO selectedShipData;
    [SerializeField] private Score_LifeDataSO currentHealth;
    [SerializeField] private PaletteSO paletteColor;

    void Start()
    {
        if (selectedShipData.selectedShip != null)
        {
            currentHealth.currentlife = selectedShipData.selectedShip.maxHealth;
            this.GetComponent<SpriteRenderer>().color = paletteColor.color;
        }
        else
        {
            Debug.LogWarning("No se ha seleccionado una nave.");
            currentHealth.currentlife = 1;
        }
    }
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Shoot();
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth.currentlife -= amount;

        if (currentHealth.currentlife <= 0)
        {
            currentHealth.currentlife = 0;
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Jugador destruido");
        SceneManager.LoadScene("Results");
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.right * bulletSpeed;
        }
    }
}
