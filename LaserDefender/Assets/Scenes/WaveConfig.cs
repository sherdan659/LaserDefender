using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{

    [SerializeField] GameObject eneryPrefab;

    [SerializeField] GameObject pathPrefab;

    [SerializeField] float timeBetweenSpawns = 0.5f;

    [SerializeField] float spawnRandomFactor = 0.3f;

    [SerializeField] int numberOfEnemies = 5;

    [SerializeField] float enemyMoveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return eneryPrefab;
    }
    /*
    public GameObject GetPathPrefab()
    {
        return pathPrefab;
    }
    */

    public List<Transform> GetWaypoints()
    {
        //Creating a empty list to place each waypoint from the pathprefab inside this list.
        List<Transform> waypoint = new List<Transform>();


        //Syntax for a Foreach is a foreach item ( indicate type of item and gve it a temp name) in collection
        foreach (Transform child in pathPrefab.transform)
        {   
            //Go trough all of the pathprefabs children (which are the waypoints for the path) and place each one in the waypoints list.
            waypoint.Add(child);

            
        }
        return waypoint;
    }

    public float GetTimeBeetweenSpawns()
    {
        return timeBetweenSpawns;
    }
    
    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }
}
