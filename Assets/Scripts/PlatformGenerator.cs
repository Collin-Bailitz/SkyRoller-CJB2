using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform player;
    public GameObject[] platformPrefabs;

    public float platformLength = 20f;
    public int platformsAhead = 5;
    public int platformsBehind = 2;

    float nextSpawnZ = 0f;
    List<GameObject> spawnedPlatforms = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < platformsAhead; i++)
        {
            SpawnPlatform();
        }
    }

    private void Update()
    {
        if (player.position.z + (platformsAhead * platformLength) > nextSpawnZ)
        {
            SpawnPlatform();
        }

        RemoveOldPlatforms();
    }

    void SpawnPlatform()
    {
        int randomIndex = Random.Range(0, platformPrefabs.Length);

        GameObject platform = Instantiate(
            platformPrefabs[randomIndex],
            new Vector3(0f, 0f, nextSpawnZ),
            Quaternion.identity
        );

        spawnedPlatforms.Add(platform);
        nextSpawnZ += platformLength;
    }

    void RemoveOldPlatforms()
    {
        if (spawnedPlatforms.Count == 0) return;

        GameObject oldestPlatform = spawnedPlatforms[0];

        if (oldestPlatform.transform.position.z < player.position.z - (platformsBehind * platformLength))
        {
            spawnedPlatforms.RemoveAt(0);
            Destroy(oldestPlatform);
        }
    }
}