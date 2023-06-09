using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCrush : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private GameEnd _gameEnd;
    [SerializeField] private GameObject _fuelCheck;
    void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.tag == "Obstacle")
        {
            CrushPlane();
        }
    }

    public void CrushPlane()
    {
        Instantiate(_explosion, transform.position, Quaternion.identity);
        _fuelCheck.SetActive(false);
        _gameEnd.EndGameScreen();
        gameObject.SetActive(false);
    }
}
