using Unity.Services.Analytics;
public class QuitToMapEvent : Event
  {
      public QuitToMapEvent() : base("QuitToMapEvent")
      {
      }
      public int playerLevel { set { SetParameter("playerLevel", value); } }
      public string chosenLevel { set { SetParameter("chosenLevel", value); } }
      public string chosenBoat { set { SetParameter("chosenBoat", value); } }
      public string[] chosenPowerups { set { SetParameter("chosenPowerups", string.Join(",", value)); } }
      public float timeInLevel { set { SetParameter("playerLevel", value); } }
  }