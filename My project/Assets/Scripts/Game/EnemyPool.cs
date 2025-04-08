using UnityEngine;
using System.Collections.Generic;


public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance; // Singleton para acceso fácil
    public GameObject enemyPrefab;
    public int poolSize = 10;

    private Queue<GameObject> enemyPool = new Queue<GameObject>();

    void Awake()
    {
        Instance = this;
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
        }
    }

    public GameObject GetEnemy()
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        }

        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.SetActive(true);
        return newEnemy;
    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }
}
