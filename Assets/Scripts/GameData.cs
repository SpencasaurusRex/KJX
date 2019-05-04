using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameData
{
    public List<GameObject> Airports = new List<GameObject>();
    public AirportData[] AirportData = new AirportData[0];
    public TextMeshPro[] AirportText = new TextMeshPro[0];

    public bool AreConnected(int i, int j) => AirportData[i].Connections.Contains(j);
}