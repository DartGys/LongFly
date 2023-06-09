using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlane : MonoBehaviour
{
    [SerializeField] private PlaneStorage _planeStorage;
    [SerializeField] private GameObject _planeParent;

    [SerializeField] private Vector3 position;
    [SerializeField] private Quaternion quaternion;
    void Start()
    {
        GameObject plane = _planeStorage.getPlane(PlayerPrefs.GetInt("Plane", 0));
        var spawnPlane = Instantiate(plane, position, quaternion);
        _planeParent.transform.position = position;
        _planeParent.transform.rotation = spawnPlane.transform.rotation;
        spawnPlane.transform.localScale = _planeParent.transform.localScale;
        spawnPlane.transform.SetParent(_planeParent.transform);
    }

}
