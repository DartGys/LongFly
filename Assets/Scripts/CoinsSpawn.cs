using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _coin;

    void Start()
    {
        StartCoroutine("fuelSpawn");
    }

    IEnumerator fuelSpawn()
    {
        yield return new WaitForSeconds(5f);

        while (true)
        {
            int coinsQuantity = Random.Range(2, 7);

            var position = new Vector3(Random.Range(-1.25f, 1.25f), Random.Range(3.5f, 5.5f), Random.Range(RoadPosition.StartPos, RoadPosition.EndPos));

            for (int i = 0; i < coinsQuantity; i++)
            {
                var newBird = Instantiate(_coin, position, Quaternion.Euler(180, 0, 0));
                position += new Vector3(0, 0, 1.5f);
            }

            yield return new WaitForSeconds(Random.Range(5f, 15f));
        }
    }
}
