using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject _startRoad;
    [SerializeField] private GameObject _birdsSpawn;
    [SerializeField] private GameObject _coinSpawn;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _fuelBar;
    [SerializeField] private GameObject _spawnFuel;
    [SerializeField] private PlaneFuel _planeFuel;


    void Awake()
    {
        Instantiate(_startRoad, new Vector3(0f, 0f, 70f), Quaternion.identity);
    }

    public void StartGame()
    {
        _planeFuel.StartCoroutine("fuelChange");
        _birdsSpawn.SetActive(true);
        _coinSpawn.SetActive(true);
        _fuelBar.SetActive(true);
        _spawnFuel.SetActive(true);
        _player.GetComponent<PlayerMovement>().enabled = true;
        _player.GetComponent<AudioSource>().enabled = true;

    }
}
