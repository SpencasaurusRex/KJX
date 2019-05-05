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
        bool left = Input.GetMouseButtonDown(0);
        bool right = Input.GetMouseButtonDown(1);
        if (left == right) return;
        
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        if (hit.transform == null) return;
        
        for (int i = 0; i < gameData.Airports.Count; i++)
        {
            if (hit.transform != gameData.Airports[i].transform) continue;
            if (left) LeftClick(i);
            if (right) RightClick(i);
        }
    }

    public void LeftClick(int i)
    {
        // Check to see if there are enough airplanes to fly
        if (gameData.AirportData[i].CurrentNumber < gameData.AirportData[i].Connections.Count)
        {
            // TODO: Visual
            return;
        }

        // Change delta
        gameData.AirportData[i].Delta -= gameData.AirportData[i].Connections.Count;
        var connections = gameData.AirportData[i].Connections;
        foreach (int connectionIndex in connections)
        {
            // TODO: Visual
            gameData.AirportData[connectionIndex].Delta++;
        }
    }

    public void RightClick(int i)
    {
        AirportData airport = gameData.AirportData[i];
        foreach (int connectionIndex in airport.Connections)
        {
            if (gameData.AirportData[connectionIndex].CurrentNumber > 0)
            {
                // TODO: Visual
                gameData.AirportData[connectionIndex].Delta--;
                airport.Delta++;
            }
        }
    }
}