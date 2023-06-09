using UnityEngine;

public class PlaneStorage : MonoBehaviour
{
    [SerializeField] private GameObject[] _planes;

    public GameObject getPlane(int planeKey)
    {
        return _planes[planeKey];
    }
}
