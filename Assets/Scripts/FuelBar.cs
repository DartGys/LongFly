using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{

    [SerializeField] private Image _fuelAmountFilling;

    [SerializeField] private PlaneFuel _planeFuel;

    // Start is called before the first frame update
    void Awake()
    {
        _planeFuel.FuelAmountChanged += OnFuelAmountChanged;
    }

    private void OnDestroy()
    {
        _planeFuel.FuelAmountChanged -= OnFuelAmountChanged;
    }

    private void OnFuelAmountChanged(float valueAsPercantage)
    {
        _fuelAmountFilling.fillAmount = valueAsPercantage;
    }

}
