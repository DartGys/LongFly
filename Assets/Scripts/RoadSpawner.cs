using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _road;
    [SerializeField] private SpawnTraffic _spawnTraffic;

    private float Zpos = 159.5f;

    private GameObject _prevRoad;

    public void RoadSpawn(GameObject prevRoad)
    {
        //Debug.Log("Road Spawner work");
        Instantiate(_road, new Vector3(0.5f, 0f, Zpos), Quaternion.identity);
        Destroy(_prevRoad);
        _prevRoad = prevRoad;
        Zpos += 72f;
        RoadPosition.CalculatePos(Zpos);
        _spawnTraffic.TrafficSpawn(Zpos);
    }
}
