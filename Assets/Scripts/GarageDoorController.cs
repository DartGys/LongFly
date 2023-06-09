using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoorController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private PlaneInsideGarageController _planeGarage;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void OpenClose()
    {
        StartCoroutine("OpenCloseCoroutine");
    }

    IEnumerator OpenCloseCoroutine()
    {
        _animator.SetFloat("GarageAnim", 1);
        _animator.SetTrigger("Open");
        yield return new WaitForSeconds(2f);
        _animator.SetFloat("GarageAnim", -1);
        yield return new WaitForSeconds(1.5f);
        _animator.SetTrigger("Close");
    }
}
