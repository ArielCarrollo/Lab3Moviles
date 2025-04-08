using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public float spawnInterval = 2f;
    public float spawnHeight = 5f;
    public float obstacleSpawnInterval = 3f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        float randomX = 10f;
        float randomY = Random.Range(-spawnHeight, spawnHeight);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        GameObject enemy = EnemyPool.Instance.GetEnemy();
        enemy.transform.position = spawnPosition;
        enemy.GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * enemy.GetComponent<Enemy>().moveSpeed;
    }
    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(obstacleSpawnInterval);
        }
    }
    private void SpawnObstacle()
    {
        float randomX = 10f;
        float randomY = Random.Range(-spawnHeight, spawnHeight);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        GameObject obstacle = ObstaclePool.Instance.GetObstacle();
        obstacle.transform.position = spawnPosition;
        obstacle.GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * obstacle.GetComponent<Obstacle>().moveSpeed;
    }
}