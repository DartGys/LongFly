using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointGather : MonoBehaviour
{
    [SerializeField] private Text _pointsText;

    public static float _points;

    public void PointAdd(float speed)
    {
        _points += speed / 10;
        _pointsText.text = $"{(int)_points}";
    }
}
