using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public ObstaclePool obstaclePool;

    public ObstaclePoolItem[] obstacleTypes;

    public float spawnRate = 2f;
    private float YUpperBound = -11f;
    private float YLowerBound = -16.5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnObstacle();

            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        int randomIndex =
            Random.Range(0, obstacleTypes.Length);

        GameObject prefab =
            obstacleTypes[randomIndex].prefab;

        GameObject obstacle =
            obstaclePool.GetObstacle(prefab);

        float randomY = Random.Range(YLowerBound, YUpperBound);

        obstacle.transform.position = new Vector3(
            transform.position.x,
            randomY,
            0
        );
    }
}