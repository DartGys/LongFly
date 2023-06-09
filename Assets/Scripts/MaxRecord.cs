using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxRecord : MonoBehaviour
{
    [SerializeField] private Text _maxRecord;

    public void SaveShowRecord()
    {
        Debug.Log("Record script");
        if (PlayerPrefs.HasKey("MaxRecord"))
        {
            if (PlayerPrefs.GetInt("MaxRecord") < PointGather._points)
            {
                PlayerPrefs.SetInt("MaxRecord", (int)PointGather._points);
                _maxRecord.text = $"Новий рекод: {(int)PlayerPrefs.GetInt("MaxRecord")}";
            }
            else
            {
                _maxRecord.text = $"Рекод: {(int)PlayerPrefs.GetInt("MaxRecord")}";
            }
        }
        else
        {
            PlayerPrefs.SetInt("MaxRecord", (int)PointGather._points);
            _maxRecord.text = $"Новий рекод: {(int)PlayerPrefs.GetInt("MaxRecord")}";
        }
    }


}
