using Unity.Services.Analytics;
public class PowerupUsageEvent : Event
    {
        public PowerupUsageEvent() : base("PowerupUsageEvent")
        {
        }
        public float x { set { SetParameter("x", value); } }
        public float y { set { SetParameter("y", value); } }
        public float z { set { SetParameter("z", value); } }
        public string powerup { set { SetParameter("powerup", value); } }
        public float timeInLevel { set { SetParameter("timeInLevel", value); } }
    }