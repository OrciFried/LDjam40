using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    SpawnArea[] spawnAreas;

    [SerializeField]
    float spawnInterval = 2.5f;

    [SerializeField]
    private GameObject currentEnemy;

    public GameObject CurrentEnemy { get { return currentEnemy; } set { currentEnemy = value; } }

    private void Start()
    {
        StartCoroutine(SpawnAtInterval());
    }

    IEnumerator SpawnAtInterval()
    {
        while (true)
        {

            foreach (SpawnArea sa in spawnAreas)
            {
                Instantiate(CurrentEnemy, new Vector2(Random.Range(sa.botLeftCorner.x, sa.topRightCorner.x), Random.Range(sa.botLeftCorner.y, sa.topRightCorner.y)), Quaternion.identity, transform);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        foreach (SpawnArea sa in spawnAreas)
        {

            Gizmos.DrawLine(sa.botLeftCorner, new Vector2(sa.botLeftCorner.x, sa.topRightCorner.y));
            Gizmos.DrawLine(sa.topRightCorner, new Vector2(sa.botLeftCorner.x, sa.topRightCorner.y));
            Gizmos.DrawLine(sa.botLeftCorner, new Vector2(sa.topRightCorner.x, sa.botLeftCorner.y));
            Gizmos.DrawLine(sa.topRightCorner, new Vector2(sa.topRightCorner.x, sa.botLeftCorner.y));
        }
    }
}

[System.Serializable]
public class SpawnArea
{
    public Vector2 botLeftCorner = -Vector2.one;
    public Vector2 topRightCorner = Vector2.one;
}
