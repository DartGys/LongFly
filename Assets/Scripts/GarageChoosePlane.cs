using UnityEngine;

public class GarageChoosePlane : MonoBehaviour
{
    int planeNumber;
    private GameObject _nextPlane;
    [SerializeField] private GameObject _planeParent;
    [SerializeField] private PlaneStorage _planeStorage;
    [SerializeField] private BuyNewPlane _buyNewPlane;

    void Start()
    {
        planeNumber = PlayerPrefs.GetInt("Plane", 0);
    }

    public void PrevPlane()
    {
        if (planeNumber == 0) planeNumber = 5;
        else planeNumber--;
    }

    public void NextPlane()
    {
        if (planeNumber == 5) planeNumber = 0;
        else planeNumber++;
    }

    public void ChoosePlane()
    {
        Destroy(_planeParent.transform.GetChild(0).gameObject);
        _nextPlane = Instantiate(_planeStorage.getPlane(planeNumber), _planeParent.transform.position, Quaternion.identity);
        Debug.Log(_nextPlane.name);
        _nextPlane.transform.SetParent(_planeParent.transform);
    }

    public int GetPlaneNumer()
    {
        return planeNumber;
    }

    public GameObject GetPlane()
    {
        return _nextPlane;
    }
}
