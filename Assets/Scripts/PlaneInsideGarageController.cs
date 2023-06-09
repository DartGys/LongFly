using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneInsideGarageController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private GameObject _plane;

    void Start()
    {
        _animator = _plane.GetComponent<Animator>();
    }

    public void GoInsideGarage()
    {
        _animator.SetFloat("GoGarageAnim", 1);
        _animator.SetTrigger("GoInsideGarage");
    }

    IEnumerator GoOutsideGarage()
    {
        _animator.SetFloat("GoGarageAnim", -1);
        yield return new WaitForSeconds(2.5f);
        _animator.SetTrigger("OutOfGarage");
    }
}
