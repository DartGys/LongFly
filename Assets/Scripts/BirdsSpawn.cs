using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsSpawn : MonoBehaviour
{
    private float StartPos;
    private float EndPos;

    public float Timer = 3f;
    public float START = 5f;
    [SerializeField] private GameObject _birds;

    private int ciclesToSpeedUp = 3;
    private float speedUpTimerDelta = 0.15f;
    private float timerMinimum = 0.75f;
    private int instantiatingCount = 0;

    void Start()
    {
        StartCoroutine("instant");
    }

    IEnumerator instant()
    {
        yield return new WaitForSeconds(START);

        while (true)
        {

            var newBird = Instantiate(_birds, new Vector3(Random.Range(-1.25f, 1.25f), Random.Range(3.5f, 5.5f), Random.Range(RoadPosition.StartPos, RoadPosition.EndPos)), Quaternion.identity);
            newBird.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -200), ForceMode.Acceleration);
            Debug.Log("Birds spawned");
            ++instantiatingCount;

            if (instantiatingCount == ciclesToSpeedUp)
            {
                if (Timer > timerMinimum)
                {
                    Timer -= speedUpTimerDelta;
                    Debug.Log($"TimerSpawn reduce to {Timer}");
                    instantiatingCount = 0;
                }

            }

            yield return new WaitForSeconds(Timer);
        }
    }
}
