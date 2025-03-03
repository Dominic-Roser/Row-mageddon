using Unity.Services.Analytics;
public class PowerupUsageEvent : Event
    {
        public PowerupUsageEvent() : base("PowerupUsageEvent")
        {
        }
        public float x { set { SetParameter("xcoord", value); } }
        public float y { set { SetParameter("ycoord", value); } }
        public float z { set { SetParameter("zcoord", value); } }
        public string powerup { set { SetParameter("powerup", value); } }
        public string chosenLevel { set { SetParameter("chosenLevel", value); } }
        public float timeInLevel { set { SetParameter("timeInLevel", value); } }
    }