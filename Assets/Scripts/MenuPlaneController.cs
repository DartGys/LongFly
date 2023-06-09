using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlaneController : MonoBehaviour
{
    [SerializeField] private GameObject _plane;
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameObject _garageCanvas;

    private Animator _animator;

    void Start()
    {
        _animator = _plane.GetComponent<Animator>();
    }

    public void PlaneTakeOff()
    {
        _animator.SetTrigger("TakeOff");
    }

    public void PlaneGoToGarage()
    {
        _animator.SetTrigger("GoToGarage");
        StartCoroutine("Garage");

    }

    public void PlaneBackToStartPos()
    {
        _animator.SetTrigger("BackToStartPos");
        StartCoroutine("Menu");
    }

    IEnumerator Menu()
    {
        yield return new WaitForSeconds(1.3f);
        _menuCanvas.SetActive(true);
    }

    IEnumerator Garage()
    {
        yield return new WaitForSeconds(1.3f);
        _garageCanvas.SetActive(true);
    }
}
