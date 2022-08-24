using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private Transform _pathPrefab;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float timeBetweenEnemySpawn = 1f;
    [SerializeField] private float spawnTimeVarience = 0f;
    [SerializeField] private float minimumSpawnTime = 0.2f;

    public int GetEnemyCount()
    {
        return _enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return _enemyPrefabs[index];
    }

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


    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawn - spawnTimeVarience,
                             timeBetweenEnemySpawn + spawnTimeVarience);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }


}
