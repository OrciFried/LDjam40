using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    Transform player;

    [SerializeField]
    float speedMultiplier = 5;

    [SerializeField]
    Vector3 offset;

    [SerializeField]
    SpawnArea sa;

    private void Awake()
    {
        if (player == null)
            player = FindObjectOfType<Player>().transform;
    }

    private void FixedUpdate()
    {
        if (player.transform.position.x < sa.topRightCorner.x && player.transform.position.x > sa.botLeftCorner.x && player.transform.position.y < sa.topRightCorner.y && player.transform.position.y > sa.botLeftCorner.y)
            transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z) + offset,
                Time.deltaTime * speedMultiplier);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(sa.botLeftCorner, new Vector2(sa.botLeftCorner.x, sa.topRightCorner.y));
        Gizmos.DrawLine(sa.topRightCorner, new Vector2(sa.botLeftCorner.x, sa.topRightCorner.y));
        Gizmos.DrawLine(sa.botLeftCorner, new Vector2(sa.topRightCorner.x, sa.botLeftCorner.y));
        Gizmos.DrawLine(sa.topRightCorner, new Vector2(sa.topRightCorner.x, sa.botLeftCorner.y));
    }
}
