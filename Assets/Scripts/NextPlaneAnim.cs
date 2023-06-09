using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPlaneAnim : MonoBehaviour
{
    [SerializeField] private GarageDoorController _garageDoor;
    [SerializeField] private PlaneInsideGarageController _planeGarage;
    [SerializeField] private GarageChoosePlane _planeChoose;
    [SerializeField] private GameObject _garageCanvas;
    [SerializeField] private BuyNewPlane _buyNewPlane;
    private AudioSource _paintSound;

    void Start()
    {
        _paintSound = gameObject.GetComponent<AudioSource>();
    }

    public void AnimNextPlane()
    {
        StartCoroutine("AnimCoroutine");
    }

    IEnumerator AnimCoroutine()
    {
        _garageDoor.OpenClose();
        yield return new WaitForSeconds(1f);
        _planeGarage.GoInsideGarage();
        yield return new WaitForSeconds(2f);
        _paintSound.Play();
        yield return new WaitForSeconds(0.5f);
        _planeChoose.ChoosePlane();
        yield return new WaitForSeconds(0.5f);
        _garageDoor.OpenClose();
        _planeGarage.StartCoroutine("GoOutsideGarage");
        _buyNewPlane.PlaneCheck();
        yield return new WaitForSeconds(3f);
        _garageCanvas.SetActive(true);
    }
}
