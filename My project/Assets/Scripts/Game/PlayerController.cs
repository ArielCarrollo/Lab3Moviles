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

    private float timeSinceLastShot;
    private bool isTouching;

    void Start()
    {
        currentHealth.ResetScore();
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

        timeSinceLastShot = 0f;
        isTouching = false;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouching = true;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouching = false;
            }
        }
        else
        {
            isTouching = false;
        }

        if (isTouching)
        {
            timeSinceLastShot += Time.deltaTime;

            if (selectedShipData.selectedShip != null &&
                timeSinceLastShot >= selectedShipData.selectedShip.Cadence)
            {
                Shoot();
                timeSinceLastShot = 0f; 
            }
        }
        else
        {
            timeSinceLastShot = 0f;
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
        GameObject bullet = BulletPool.Instance.GetBullet();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = Quaternion.identity;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.right * bulletSpeed;
        }
    }
}
