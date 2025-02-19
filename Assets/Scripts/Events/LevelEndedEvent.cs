using System;
using Unity.Services.Analytics;
public class LevelEndedEvent : Event
    {
        public LevelEndedEvent() : base("LevelEndedEvent")
        {
        }
        public int playerLevel { set { SetParameter("playerLevel", value); } }
        public string chosenLevel { set { SetParameter("chosenLevel", value); } }
        public string[] chosenPowerups { set { SetParameter("chosenPowerups", string.Join(",", value)); } }
        public bool win { set { SetParameter("win", value); } }
        public float timeInLevel { set { SetParameter("timeInLevel", value); } }
        public string chosenBoat { set { SetParameter("chosenBoat", value); } }

    }