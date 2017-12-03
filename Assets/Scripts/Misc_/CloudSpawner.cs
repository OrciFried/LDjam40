using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float randomXSpawnFrom = -1, randomXSpawnTo = 1, randomYSpawnFrom = -1, randomYSpawnTo;

    [SerializeField]
    int amountOfCloudsAtStart = 3;

    [SerializeField]
    SpawnArea[] spawnAreas;

    [SerializeField]
    float timeInterval = 5;

    private void Start()
    {
        foreach (SpawnArea sa in spawnAreas)
        {
            for (int i = 0; i < amountOfCloudsAtStart; i++)
                Instantiate(clouds[Random.Range(0, clouds.Length)], new Vector2(Random.Range(sa.botLeftCorner.x, sa.topRightCorner.x), Random.Range(sa.botLeftCorner.y, sa.topRightCorner.y)), Quaternion.identity, transform);
        }
        StartCoroutine(SpawnClouds());
    }

    IEnumerator SpawnClouds()
    {
        while (true)
        {
            Instantiate(clouds[Random.Range(0, clouds.Length)], new Vector2(Random.Range(randomXSpawnFrom, randomXSpawnTo), Random.Range(randomYSpawnFrom, randomYSpawnTo)), Quaternion.identity, transform);
            yield return new WaitForSeconds(timeInterval);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        foreach (SpawnArea sa in spawnAreas)
        {

            Gizmos.DrawLine(sa.botLeftCorner, new Vector2(sa.botLeftCorner.x, sa.topRightCorner.y));
            Gizmos.DrawLine(sa.topRightCorner, new Vector2(sa.botLeftCorner.x, sa.topRightCorner.y));
            Gizmos.DrawLine(sa.botLeftCorner, new Vector2(sa.topRightCorner.x, sa.botLeftCorner.y));
            Gizmos.DrawLine(sa.topRightCorner, new Vector2(sa.topRightCorner.x, sa.botLeftCorner.y));
        }
    }
}
