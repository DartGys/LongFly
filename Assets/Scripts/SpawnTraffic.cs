using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTraffic : MonoBehaviour
{
    [SerializeField] private GameObject[] _cars;

    [SerializeField] private GameObject _truck;

    private int TruckChanceCalculate = 15;

    void Start()
    {
        StartCoroutine("truckChanceIncrease");
    }

    public void TrafficSpawn(float endPos)
    {
        //Debug.Log("Traffic Spawn work");

        float startPos = RoadPosition.StartPos;

        int carCount = Random.Range(1, 5);
        float roadPart = RoadPosition.RoadPart(carCount);
        //Debug.Log($"CarCount = {carCount}");
        for (int i = 0; i < carCount; i++)
        {
            int route = Random.Range(1, 3);
            // if route = 1 : left side of road. If route = 2 : right side of road
            //Debug.Log($"Route = {route}");
            int TruckSpawnChance = Random.Range(1, 100);
            // chance of spawn truck 
            Debug.Log($"Truck spawn chance = {TruckSpawnChance}");
            if (route == 1)
            {
                var newCar = Instantiate(TruckSpawnChance <= TruckChanceCalculate ? _truck : _cars[Random.Range(0, 4)], new Vector3(-1.25f, 0, Random.Range(startPos, roadPart)), TruckSpawnChance <= TruckChanceCalculate ? Quaternion.Euler(0, 180, 0) : Quaternion.identity);
                newCar.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -200), ForceMode.Acceleration);
                //Debug.Log($"{newCar.name} was spawn on Z: {newCar.transform.position.z}");
                if (newCar.tag == "Obstacle") Debug.Log($"Truck was spawn with chance {TruckSpawnChance}");
                startPos = roadPart;
                roadPart += RoadPosition.Distance / carCount;
            }
            if (route == 2)
            {
                var newCar = Instantiate(TruckSpawnChance <= TruckChanceCalculate ? _truck : _cars[Random.Range(0, 4)], new Vector3(1.25f, 0, Random.Range(startPos, roadPart)), TruckSpawnChance <= TruckChanceCalculate ? Quaternion.identity : Quaternion.Euler(0, 180, 0));
                newCar.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 200), ForceMode.Acceleration);
                //Debug.Log($"{newCar.name} was spawn on Z: {newCar.transform.position.z}");
                if (newCar.tag == "Obstacle") Debug.Log($"Truck was spawn with chance {TruckSpawnChance}");
                startPos = roadPart;
                roadPart += RoadPosition.Distance / carCount;
            }
        }
    }

    public float Timer = 7.5f;
    public float START = 10f;

    private int ciclesToSpeedUp = 2;
    private int chanceIncrease = 7;
    private int maxChance = 85;
    private int instantiatingCount = 0;

    IEnumerator truckChanceIncrease()
    {
        yield return new WaitForSeconds(START);

        while (true)
        {
            ++instantiatingCount;

            if (instantiatingCount == ciclesToSpeedUp)
            {
                if (TruckChanceCalculate < maxChance)
                {
                    TruckChanceCalculate += chanceIncrease;
                    Debug.Log($"Chance increase to {TruckChanceCalculate}");
                    instantiatingCount = 0;
                }
            }

            yield return new WaitForSeconds(Timer);
        }
    }
}

