using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // variables
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 1.5f;
    public float obstacleSpeed;
    private float YUpperBound = -11f;
    private float YLowerBound = -17.5f;
    private float ZBound = -2;
    private float timeUntilObstacleSpawn;
    private GameManager gameManager;

    private void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void Update() {
        SpawnLoop();
        obstacleSpeed = 2f + Mathf.FloorToInt(gameManager.score * 0.03f);
        
        if (gameManager.score > 100) {
            //obstacleSpeed = 10f;
            obstacleSpawnTime = 1f;
        }
        else if (gameManager.score > 300) {
            //obstacleSpeed = 20f;
            obstacleSpawnTime = 0.5f;
        }

        else if (gameManager.score > 500) {
            obstacleSpawnTime = 0.25f;
        }

    }

    private void SpawnLoop() {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn > obstacleSpawnTime && gameManager.isGameActive) {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void Spawn() {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(YLowerBound, YUpperBound), ZBound);

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, spawnPos, Quaternion.identity);

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    
    } 
}
