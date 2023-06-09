using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyNewPlane : MonoBehaviour
{
    private GameObject _curPlane;
    private int _planeNumber;
    [SerializeField] private GameObject _buyButton;
    [SerializeField] private Text _price;
    [SerializeField] private GameObject _priceText;
    [SerializeField] private GameObject _selectButton;
    [SerializeField] private GarageChoosePlane _garageChoose;
    [SerializeField] private GameObject _exitButton;

    void Start()
    {
        PlayerPrefs.SetInt("Plane1(Clone)", 1);
    }

    public void PlaneCheck()
    {
        _curPlane = _garageChoose.GetPlane();
        _planeNumber = _garageChoose.GetPlaneNumer();

        if (PlayerPrefs.GetInt(_curPlane.name, 0) == 0)
        {
            _buyButton.SetActive(true);
            _priceText.SetActive(true);
            _price.text = $"{PlanePrices.prices[_planeNumber]}";
            _exitButton.SetActive(false);
            _selectButton.SetActive(false);
        }
        else if (PlayerPrefs.GetInt(_curPlane.name, 0) == 1)
        {
            _exitButton.SetActive(true);
            _buyButton.SetActive(false);
            _priceText.SetActive(false);
            if (PlayerPrefs.GetInt("Plane") != _planeNumber)
            {
                _selectButton.SetActive(true);
            }
        }
    }
}
