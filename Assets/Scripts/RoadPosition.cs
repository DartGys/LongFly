using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPosition
{
    public static float EndPos;
    public static float StartPos;
    public static float Distance;

    public static void CalculatePos(float gotEndPos)
    {
        EndPos = gotEndPos;
        StartPos = EndPos - 70f;
        Distance = EndPos - StartPos;

    }

    public static float RoadPart(int PartCount)
    {
        return StartPos + (Distance / PartCount);
    }
}
