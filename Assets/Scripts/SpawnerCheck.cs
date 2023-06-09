using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCheck : MonoBehaviour
{
    [SerializeField] private RoadSpawner _roadSpawner;
    [SerializeField] private DestroyTraffic _destroyTraffic;

    void OnTriggerEnter(Collider checkBox)
    {
        if (checkBox.name == "CheckSpawner")
        {
            //Debug.Log("SpawnCheck");
            var prevRoad = checkBox.gameObject.transform.parent.gameObject;
            //Debug.Log(prevRoad.name);
            checkBox.enabled = false;
            _destroyTraffic.TrafficDestroy(checkBox.gameObject.transform);
            _roadSpawner.RoadSpawn(prevRoad);
        }
    }
}
