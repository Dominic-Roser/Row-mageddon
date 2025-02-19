using System;
using Unity.Services.Analytics;
public class LevelStartedEvent : Event
    {
        public LevelStartedEvent() : base("LevelStartedEvent")
        {
        }
        public int playerLevel { set { SetParameter("playerLevel", value); } }
        public string chosenLevel { set { SetParameter("chosenLevel", value); } }
        public string chosenBoat { set { SetParameter("chosenLevel", value); } }
        public string[] chosenPowerups { set { SetParameter("chosenPowerups", string.Join(",", value)); } }
    }