using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneOutOfFuel : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private ParticleSystem _explosion;

    [SerializeField] private PlaneCrush _planeCrush;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    IEnumerator PlaneCrush()
    {
        _animator.enabled = true;
        yield return new WaitForSeconds(1);
        _planeCrush.CrushPlane();
    }
}
