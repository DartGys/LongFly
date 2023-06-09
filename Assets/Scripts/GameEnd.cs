using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private Text _pointsCountText;
    [SerializeField] private GameObject _gameEnd;
    [SerializeField] private GameObject _birds;
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private MaxRecord _Record;
    public void EndGameScreen()
    {
        Debug.Log("GameEnd");
        _gameEnd.SetActive(true);
        _pointsCountText.text += (int)PointGather._points;
        _Record.SaveShowRecord();
        _birds.SetActive(false);
        _mainCanvas.SetActive(false);
    }
}
