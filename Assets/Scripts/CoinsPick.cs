using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPick : MonoBehaviour
{
    [SerializeField] private CoinQuantity _coinQuantityShow;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Coin")
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin", 0) + 1);
            _coinQuantityShow.showCoinQuantity();
            Destroy(collider.gameObject);
        }
    }
}
