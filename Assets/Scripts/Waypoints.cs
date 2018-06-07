using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    // making array with all waypoints
    public static Transform[] points;

    void Awake()
    {
        // summarizing all waypoints
        points = new Transform[transform.childCount];

        // placing waypoints into array
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
