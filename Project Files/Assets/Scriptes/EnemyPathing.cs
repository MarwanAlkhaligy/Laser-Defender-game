using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // Start is called before the first frame update
    Wave wavewaypoint;
    List<Transform> WayPoint; 

    private int wayPointIndex = 0;

    void Start()
    {
        WayPoint = wavewaypoint.GetWavewaypoints();
        transform.position =  WayPoint[wayPointIndex].transform.position;
    }
    public void SetWave(Wave wave)
    {
        wavewaypoint = wave;
    }
    // Update is called once per frame
    private void Update()
    {
        Move(); 
    }

    private void Move()
    {
        if(wayPointIndex < WayPoint.Count)
        {
            var targetPosition = WayPoint[wayPointIndex].transform.position;
            var movePerFrame = wavewaypoint.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movePerFrame);

            if(transform.position == targetPosition)
            {
                wayPointIndex++;
            }   
        }   
        else
        {
            Destroy(gameObject);
        }
    }
}
