using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private Transform _pathPrefab;
    [SerializeField] private float _moveSpeed = 5f;

    public Transform GetStartingWaypoint()
    {
        return _pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        
        foreach (Transform child in _pathPrefab)
        {
            wayPoints.Add(child);
        }

        return wayPoints;

    }

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }

}
