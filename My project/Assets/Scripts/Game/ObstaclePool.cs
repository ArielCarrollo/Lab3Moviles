using UnityEngine;
using System.Collections.Generic;

public class ObstaclePool : MonoBehaviour
{
    public static ObstaclePool Instance;
    public GameObject obstaclePrefab;
    public int poolSize = 8;

    private Queue<GameObject> obstaclePool = new Queue<GameObject>();

    void Awake()
    {
        Instance = this;
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefab);
            obstacle.SetActive(false);
            obstaclePool.Enqueue(obstacle);
        }
    }

    public GameObject GetObstacle()
    {
        if (obstaclePool.Count > 0)
        {
            GameObject obstacle = obstaclePool.Dequeue();
            obstacle.SetActive(true);
            return obstacle;
        }

        // Si no hay obstáculos disponibles, creamos uno nuevo
        GameObject newObstacle = Instantiate(obstaclePrefab);
        newObstacle.SetActive(true);
        return newObstacle;
    }

    public void ReturnObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);
        obstaclePool.Enqueue(obstacle);
    }
}
