using UnityEngine;
using System.Collections.Generic;

public class PowerupData : MonoBehaviour
{

    public static Dictionary<string, string> raceplanTooltips = new Dictionary<string, string>{
        {"Torpedo", "Torpedo: An explosive homing\ndevice that explodes enemies"},
        {"SpeedBoost", "Speed Boost: An exhilerating\nboost to your rowing speed"},
        {"FishingRod", "Fishing Rod: A powerful\ntackle tool to reel the enemies in"},
        {"Beer", "Beer: A beverage as old as time,\nused to intoxicate the opponents"},
        {"WaterGun", "Water Gun: A childhood toy with\nimmense power to push enemies"},
        {"SideCannon", "Side Cannon: A powerful weapon\nthat looks left and right"},
        {"Whirlpool", "Whirlpool: Left in your wake for\nenemies to get stuck in"},
        {"Lightning", "Lightning: shocks em' so much\nthat they srhink!"},
        {"Reflect", "Reflect: I don't like it so I'm\nsending it back!"},

        {"ForceField", "Force Field: A protective barrier \nfrom enemy attacks"},
        {"Dragon boat", "Dragon Boat: His name is wiggles"},
        {"WoodenBoat", "Wooden Boat: Ol' Reliable"},
        {"PurpleBoat", "Purple Boat: Go Dawgs!"},
    };
}
