public class AirportTextUpdater
{
    readonly GameData gameData;

    public AirportTextUpdater(GameData data)
    {
        gameData = data;
    }

    public void Update()
    {
        for (int i = 0; i < gameData.Airports.Count; i++)
        {
            var data = gameData.AirportData[i];
            if (!data.Dirty) continue;
            
            var text = gameData.AirportText[i];
            text.text = data.CurrentNumber + " / " + data.TargetNumber;
            data.Dirty = false;
        }
    }
}