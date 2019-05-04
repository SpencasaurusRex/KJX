using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Level[] Levels;
    public GameObject AirportPrefab;
    
    GameData data;

    AirportTextUpdater textUpdater;
    AirportClickHandler clickHandler;

    void Awake()
    {
        data = new GameData();
    }

    void Start()
    {
        clickHandler = new AirportClickHandler(data);
        textUpdater = new AirportTextUpdater(data);
        LoadLevel(0);
    }

    void LoadLevel(int index)
    {
        // Remove old level
        foreach (GameObject airport in data.Airports)
        {
            Destroy(airport);
        }
        data.Airports.Clear();

        //Load new level
        var newLevel = Levels[index];

        data.AirportText = new TextMeshPro[newLevel.Airports.Length];
        data.AirportData = newLevel.Airports; 
        for (int i = 0; i < newLevel.Airports.Length; i++)
        {
            var airportData = data.AirportData[i];
            airportData.Dirty = true;

            data.Airports.Add(Instantiate(AirportPrefab));
            data.Airports[i].transform.position = new Vector3(airportData.X, airportData.Y);
            data.AirportText[i] = data.Airports[i].GetComponentInChildren<TextMeshPro>();
        }
    }

    void Update()
    {
        textUpdater.Update();
        clickHandler.Update();
    }
}
