using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] float enemyMoveSpeed = 2f;

    int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
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
            var movementThisFrame = enemyMoveSpeed * Time.deltaTime;
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
}
