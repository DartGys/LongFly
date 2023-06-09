using System.Collections;
using System;
using UnityEngine;

public class PlaneFuel : MonoBehaviour
{
    [SerializeField] private PlaneOutOfFuel _planeOutOfFuel;

    public event Action<float> FuelAmountChanged;

    public float Timer = 0.2f;
    private float GazAmount = 100f;

    IEnumerator fuelChange()
    {
        while (true)
        {
            if (GazAmount > 0)
            {
                GazAmount -= 0.5f;
                FuelAmountChanged?.Invoke(GazAmount / 100);
            }
            else
            {
                _planeOutOfFuel.StartCoroutine("PlaneCrush");
                break;
            }

            yield return new WaitForSeconds(Timer);
        }
    }

    public void FuelAdd()
    {
        if (GazAmount + 30 > 100) GazAmount = 100f;
        else GazAmount += 30f;
    }
}
