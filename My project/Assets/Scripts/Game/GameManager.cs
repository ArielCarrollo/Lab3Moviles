using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;        
    public float spawnInterval = 2f;      
    public float spawnHeight = 5f;        

    private void Start()
    {
        StartCoroutine(SpawnEnemies());   
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy(); 
            yield return new WaitForSeconds(spawnInterval);  
        }
    }

    // Método que spawnea un enemigo
    private void SpawnEnemy()
    {
        float randomX = 10f;  
        float randomY = Random.Range(-spawnHeight, spawnHeight);  
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f); 

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
