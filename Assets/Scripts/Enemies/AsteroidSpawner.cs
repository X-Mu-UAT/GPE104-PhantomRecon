using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Asteroid Configuration")]
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private int totalAsteroids = 50;

    [Header("Spawn Boundaries (100m x 100m x 100m)")]
    [SerializeField] private Vector3 spawnRange = new Vector3(90f, 90f, 90f);
    [SerializeField] private float minimumHeight = 5f; // Keeps asteroids off the ground plane

    [Header("Randomization Modifiers")]
    [SerializeField] private float minScale = 1f;
    [SerializeField] private float maxScale = 5f;

    private void Start()
    {
        if (asteroidPrefab == null)
        {
            Debug.LogError("Asteroid Spawner is missing its Asteroid Prefab asset!");
            return;
        }

        SpawnAsteroidField();
    }

    private void SpawnAsteroidField()
    {
        for (int i = 0; i < totalAsteroids; i++)
        {
            // Generate a random localized position inside your test zone metrics
            float randomX = Random.Range(-spawnRange.x / 2f, spawnRange.x / 2f);
            float randomY = Random.Range(minimumHeight, spawnRange.y / 2f);
            float randomZ = Random.Range(-spawnRange.z / 2f, spawnRange.z / 2f);
            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

            // Instantiate object under this spawner as a clean child organizer
            GameObject spawnedAsteroid = Instantiate(asteroidPrefab, spawnPosition, Random.rotation, transform);

            // Randomize size scale to make the environment look organic
            float randomScale = Random.Range(minScale, maxScale);
            spawnedAsteroid.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        }
    }
}