using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelGather : MonoBehaviour
{
    [SerializeField] private PlaneFuel _planeFuel;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Fuel")
        {
            _planeFuel.FuelAdd();
            Destroy(collider.gameObject);
        }
    }
}
