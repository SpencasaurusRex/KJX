using UnityEngine;

public class AirportClickHandler
{
    readonly GameData gameData;

    public AirportClickHandler(GameData data)
    {
        gameData = data;
    }

    public void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        if (hit.transform == null) return;

        for (int i = 0; i < gameData.Airports.Count; i++)
        {
            if (hit.transform != gameData.Airports[i].transform) continue;
            var connections = gameData.AirportData[i].Connections;
            Debug.Log(i + " which is connected to " + string.Join(", ", connections));
        }
    }
}