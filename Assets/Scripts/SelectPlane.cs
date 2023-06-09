using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlane : MonoBehaviour
{
    private int _planeNumber;
    [SerializeField] private GarageChoosePlane _garageChoose;

    public void PlaneSelect()
    {
        _planeNumber = _garageChoose.GetPlaneNumer();

        PlayerPrefs.SetInt("Plane", _planeNumber);
    }
}
