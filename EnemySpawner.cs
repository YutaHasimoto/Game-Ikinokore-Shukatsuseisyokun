using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 敵のPrefab
    public float spawnRate = 2.0f; // スポーンする頻度
    public float spawnDistance = 10.0f; // プレイヤーからの距離
    private float nextSpawnTime;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        if (playerTransform != null)
        {
            Vector2 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPosition = new Vector3(playerTransform.position.x + spawnDirection.x, playerTransform.position.y + spawnDirection.y, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
