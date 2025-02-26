using UnityEngine;
using System.Collections.Generic;

public class PowerupData : MonoBehaviour
{
    public static Dictionary<string, string> powerupTooltips = new Dictionary<string, string>{
        {"Torpedo", "Torpedo: An explosive homing\ndevice that explodes enemies"},
        {"SpeedBoost", "Speed Boost: An exhilerating\nboost to your rowing speed"},
        {"FishingRod", "Fishing Rod: A powerful\ntackle tool to reel the enemies in"},
        {"Beer", "Beer: A beverage as old as time,\nused to intoxicate the opponents"},
        {"WaterGun", "Water Gun: A childhood toy with\nimmense power to push enemies"},
    };
}
