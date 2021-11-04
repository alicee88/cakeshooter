using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waveConfig.GetStartingWaypoint().transform.position;
    }

    void Update()
    {
        if(transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex++;

            if(waypointIndex == waypoints.Count)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, (waveConfig.GetMoveSpeed() * Time.deltaTime));
        }
    }
}
