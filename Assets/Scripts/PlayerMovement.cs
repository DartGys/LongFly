using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PointGather _pointGather;
    public bool moveByTouch, gameState;
    private Vector3 mouseStartPos, playerStartPos;
    private Camera _camera;
    private float strafeSpeed = 4f;
    private float UpDownSpeed = 5f;
    private float forwardSpeed = 20f;

    void Start()
    {
        _camera = Camera.main;
        StartCoroutine("speedUp");
    }
    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
        float speed = forwardSpeed * Time.deltaTime;
        transform.Translate(-Vector3.forward * speed);
        _pointGather.PointAdd(speed);
    }


    void MoveThePlayer()
    {
        if (Input.GetMouseButtonDown(0) && gameState)
        {
            moveByTouch = true;

            var plane = new Plane(Vector3.up, 0f);

            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance))
            {
                mouseStartPos = ray.GetPoint(distance + 1f);
                playerStartPos = transform.position;
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            moveByTouch = false;
        }

        if (moveByTouch)
        {
            var plane = new Plane(Vector3.up, 0f);
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance))
            {
                var mousePos = ray.GetPoint(distance + 1f);
                var move = mousePos - mouseStartPos;
                var controlX = playerStartPos + move;
                var controlY = playerStartPos + move * 8f;
                controlX.x = Mathf.Clamp(controlX.x, -2f, 2f);
                controlY.y = Mathf.Clamp(controlY.y, 2f, 5f);

                transform.position = new Vector3(
                    Mathf.Lerp(transform.position.x, controlX.x, Time.deltaTime * strafeSpeed),
                    Mathf.Lerp(transform.position.y, controlY.y, Time.deltaTime * UpDownSpeed),
                    transform.position.z);
            }
        }
    }

    public float Timer = 2f;
    public float START = 5f;

    private int ciclesToSpeedUp = 3;
    private float speedUpDelta = 0.75f;
    private float speedMax = 40f;
    private int instantiatingCount = 0;

    IEnumerator speedUp()
    {
        yield return new WaitForSeconds(START);

        while (true)
        {
            ++instantiatingCount;

            if (instantiatingCount == ciclesToSpeedUp)
            {
                if (forwardSpeed < speedMax)
                {
                    forwardSpeed += speedUpDelta;
                    Debug.Log($"Speed increase to {forwardSpeed}");
                    instantiatingCount = 0;
                }
            }

            yield return new WaitForSeconds(Timer);
        }
    }
}
