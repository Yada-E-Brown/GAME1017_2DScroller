using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;

    public Vector2 spawnAreaSize = new Vector2(2.5f, 2.5f); // width & height of the box

    private void Start()
    {
        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);

        Vector3 spawnPos = transform.position + new Vector3(randomX, 0, 0);

        Instantiate(obstacle, spawnPos, Quaternion.identity);
    }
}