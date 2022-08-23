using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    private List<Transform> _waypoints;
    private int wayPointIndex = 0;
    

    void Start()
    {
        _waypoints = waveConfig.GetWaypoints();
        transform.position = _waypoints[wayPointIndex].position;
    }


    void Update()
    {
        if (wayPointIndex < _waypoints.Count)
        {
            Vector3 targetPosition = _waypoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);

            if (transform.position == targetPosition)
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
