using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinQuantity : MonoBehaviour
{
    [SerializeField] private Text _coinQuantity;

    void Start()
    {
        showCoinQuantity();
    }

    public void showCoinQuantity()
    {
        _coinQuantity.text = $"{PlayerPrefs.GetInt("Coin", 0)}";
    }
}
