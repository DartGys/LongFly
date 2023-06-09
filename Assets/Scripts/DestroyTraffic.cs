using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTraffic : MonoBehaviour
{
    public void TrafficDestroy(Transform checkBox)
    {
        //Debug.Log("Traffic Destroy work");
        var cars = GameObject.FindGameObjectsWithTag("Car");
        var obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        var fuelTanks = GameObject.FindGameObjectsWithTag("Fuel");

        int destoyedObjects = 0;
        foreach (var car in cars)
        {
            if (car.transform.position.z < checkBox.position.z)
            {
                Destroy(car);
                destoyedObjects++;
            }
        }

        foreach (var obstacle in obstacles)
        {
            if (obstacle.transform.position.z < checkBox.position.z)
            {
                Destroy(obstacle);
                destoyedObjects++;
            }
        }

        foreach (var fueltank in fuelTanks)
        {
            if (fueltank.transform.position.z < checkBox.position.z)
            {
                Destroy(fueltank);
                destoyedObjects++;
            }
        }
        //Debug.Log($"{destoyedObjects} objects was destroyed");
    }
}
