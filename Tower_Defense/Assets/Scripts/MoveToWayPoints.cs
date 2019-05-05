using System;
using UnityEngine.UI;
using UnityEngine;

public class MoveToWayPoints : MonoBehaviour
{
    [HideInInspector]
    public float Speed;

    public Transform[] waypoints;

    int CurrentWayPointIndex = 0;

    void Update ()
    {
        if (CurrentWayPointIndex < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[CurrentWayPointIndex].position, Time.deltaTime * Speed);
            transform.LookAt(waypoints[CurrentWayPointIndex]);
            if (Vector3.Distance(transform.position, waypoints[CurrentWayPointIndex].position) <= 0.5f)
            {
                CurrentWayPointIndex++;
            }
        }
    }
}
