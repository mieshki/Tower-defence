using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Movement : MonoBehaviour {


    // enemy speed
    public float enemySpeed;

    // to get position of waypoint [target]
    private Transform target;
    // first wavepoint to reach
    private int wavepointIndex = 0;

    void Start()
    {
        enemySpeed = GameStats.Enemy3Speed;

        // setting target to first wavepoint
        target = Waypoints.points[wavepointIndex];
    }

    void Update()
    {
        // calculating distance to target
        Vector3 dir = target.position - transform.position;
        // setting direction to the targer
        transform.Translate(dir.normalized * enemySpeed * Time.deltaTime, Space.World);

        // if target is reached, change target
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

    }

    // setting new target
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
