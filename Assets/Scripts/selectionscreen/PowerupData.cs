using UnityEngine;
using System.Collections.Generic;

public class PowerupData : MonoBehaviour
{
    public static Dictionary<string, string> powerupTooltips = new Dictionary<string, string>{
        {"Torpedo", "Torpedo: An explosive homing device that explodes enemies"},
        {"SpeedBoost", "Speed Boost: An exhilerating boost to your rowing speed"},
        {"FishingRod", "Fishing Rod: A powerful tackle tool to reel the enemies in"},
        {"Beer", "Beer: A beverage as old as time, used to intoxicate the opponents"},
        {"WaterGun", "Water Gun: A childhood toy with immense power to push enemies"},
    };
}
