using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    [SerializeField]
    float randomSpeedFrom = .2f, randomSpeedTo = .6f, xThreshold = 40;

    float speed;

    void Start()
    {
        speed = Random.Range(randomSpeedFrom, randomSpeedTo);
    }

	void Update () {
        transform.position += Vector3.right * speed * Time.deltaTime;
        if (transform.position.x > xThreshold)
            Destroy(gameObject);
	}
}
