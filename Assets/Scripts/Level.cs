using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Level : ScriptableObject
{
    public AirportData[] Airports;
}

[Serializable]
public class AirportData
{
    public int CurrentNumber;
    public int TargetNumber;
    public float X;
    public float Y;

    public List<int> Connections = new List<int>();

    [HideInInspector]
    public int Delta;
    [HideInInspector]
    public bool Dirty;
}