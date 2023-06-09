using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachCamera : MonoBehaviour
{
    [SerializeField] private GameObject _plane;
    public float z;

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _plane.transform.position.z - z);
    }
}
