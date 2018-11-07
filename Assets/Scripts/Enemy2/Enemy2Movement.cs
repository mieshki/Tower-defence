using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour {

    public float enemySpeed;
    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        enemySpeed = GameStats.Enemy2Speed;
        target = Waypoints.points[wavepointIndex];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemySpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            GetNextWaypoint();
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            GameStats.lifes--;
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
