using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WaveConfig")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
   // [SerializeField] int numberOfEnemies = 1;
  //  [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float moveSpeed = 5f;

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform wp in pathPrefab)
        {
            waypoints.Add(wp);
        }
        return waypoints;
    }

}
