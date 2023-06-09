using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchasePlane : MonoBehaviour
{
    private GameObject _curPlane;
    private int _planeNumber;
    [SerializeField] private GarageChoosePlane _garageChoose;
    [SerializeField] private GameObject _textWarning;
    [SerializeField] private Text _coins;
    [SerializeField] private GameObject _priceText;
    [SerializeField] private GameObject _exitButton;

    private int[] planePrices;

    void Start()
    {
        planePrices = PlanePrices.prices;
        _coins.text = $"{PlayerPrefs.GetInt("Coin", 0)}";
    }

    public void PlanePurchase()
    {
        _curPlane = _garageChoose.GetPlane();
        _planeNumber = _garageChoose.GetPlaneNumer();

        if (PlayerPrefs.GetInt("Coin", 0) >= planePrices[_planeNumber])
        {
            Debug.Log($"{_curPlane.name} purchased");
            PlayerPrefs.SetInt(_curPlane.name, 1);
            PlayerPrefs.SetInt("Plane", _planeNumber);
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - planePrices[_planeNumber]);
            _priceText.SetActive(false);
            _exitButton.SetActive(true);
            _coins.text = $"{PlayerPrefs.GetInt("Coin", 0)}";
        }
        else
        {
            StartCoroutine("TextWarning");
        }
    }

    IEnumerator TextWarning()
    {
        _textWarning.SetActive(true);
        yield return new WaitForSeconds(1f);
        _textWarning.SetActive(false);
    }
}
