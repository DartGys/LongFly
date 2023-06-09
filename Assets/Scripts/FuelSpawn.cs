using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawn : MonoBehaviour
{

    [SerializeField] private GameObject _fuelTank;

    void Start()
    {
        StartCoroutine("fuelSpawn");
    }

    IEnumerator fuelSpawn()
    {
        yield return new WaitForSeconds(10f);

        while (true)
        {
            var newBird = Instantiate(_fuelTank, new Vector3(Random.Range(-1.25f, 1.25f), Random.Range(3.5f, 5.5f), Random.Range(RoadPosition.StartPos, RoadPosition.EndPos)), Quaternion.Euler(180, 0, 0));
            yield return new WaitForSeconds(Random.Range(5f, 15f));
        }
    }
}
