using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    //refrence to the current wave assets (tpye wave config)
    [SerializeField] WaveConfig waveConfig;


    [SerializeField] List<Transform> wayPoints;
 

    int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints = waveConfig.GetWaypoints();
        // we are setting the current enemy to be placed in the position of the first waypoint
        transform.position = wayPoints[wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        if(wayPointIndex < wayPoints.Count)
            //if(wayPointIndex <= wayPoints.Count - 1)
        {
            var movementThisFrame = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            var targetPosition = wayPoints[wayPointIndex].position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
                wayPointIndex++;
        
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
