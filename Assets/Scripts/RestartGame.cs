using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject _endGameScreen;
    public void GameRestart()
    {
        _endGameScreen.SetActive(false);
        PointGather._points = 0;
        SceneManager.LoadScene("MainGameplay");
    }
}
